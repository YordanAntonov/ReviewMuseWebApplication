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
        private readonly IEditorService editorService;

        public ReviewController(IReviewService reviewService, IBookService bookService, IEditorService editorService)
        {
            this.reviewService = reviewService;
            this.bookService = bookService;
            this.editorService = editorService;
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

        public async Task<IActionResult> RemoveReview(string id)
        {
            bool reviewExist = await this.reviewService.ReviewExistByIdAsync(id);

            if (!reviewExist)
            {
                TempData["ErrorMessage"] = "The review you selected does not exist";

                return RedirectToAction("AllBooks", "Book");
            }

            bool userIsEditor = await this.editorService.IsUserEditorById(Guid.Parse(User.GetId()));

            if (!userIsEditor)
            {
                TempData["ErrorMessage"] = "Access Denied! You must be an editor in order to access this page!";

                return RedirectToAction("Index", "Home");
            }

            TempData["SuccessMessage"] = "Successfully removed Review!";
            await this.reviewService.RemoveReviewAsync(id);

            return RedirectToAction("AllBooks", "Book");
        }
    }
}
