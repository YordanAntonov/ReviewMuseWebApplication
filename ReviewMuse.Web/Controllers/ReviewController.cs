namespace ReviewMuse.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ReviewMuse.Services.Contracts;
    using ReviewMuse.Web.Infrastructure.Extensions;
    using ReviewMuse.Web.Models.ExportModels;

    public class ReviewController : BaseController
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

            string id = model.BookId;

            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "We cannot process your review at the moment. Try again later!";

                return RedirectToAction("GetBookById", "Book", new { id = id });
            }

            string userId = User.GetId();

            await this.reviewService.SaveReviewAsync(model, userId);

            await this.bookService.AddRatingToBookAsync(model.UserReview.Rating, model.BookId!);

            TempData["SuccessMessage"] = "Thank you! You succesfully reviewed our book!";


            return RedirectToAction("GetBookById", "Book", new { id = id});
        }
    }
}
