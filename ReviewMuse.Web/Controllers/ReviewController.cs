namespace ReviewMuse.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ReviewMuse.Services.Contracts;
    using ReviewMuse.Web.Infrastructure.Extensions;
    using ReviewMuse.Web.Models.ExportModels;

    public class ReviewController : Controller
    {
        private readonly IReviewService reviewService;
        private readonly IBookService bookService;

        public ReviewController(IReviewService reviewService, IBookService bookService)
        {
            this.reviewService = reviewService;
            this.bookService = bookService;

        }

        [HttpPost]
        public async Task<IActionResult> CreateReivew(ExpoSingleBookViewModel model)
        {
            bool bookExists = await this.bookService.BookExistsById(model.BookId!);

            if (!bookExists)
            {
                TempData["ErrorMessage"] = "The book you selected does not exist in our library!";

                return RedirectToAction("AllBooks", "Book");
            }

            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "We cannot process your review at the moment. Try again later!";

                return RedirectToAction("GetBookById", "Book", model.BookId);
            }

            string userId = User.GetId();

            await this.reviewService.SaveReviewAsync(model, userId);

            return RedirectToAction("GetBookById", "Book", model.BookId);
        }
    }
}
