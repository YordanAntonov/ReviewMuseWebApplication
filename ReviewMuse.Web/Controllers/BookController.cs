namespace ReviewMuse.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using ReviewMuse.Services.Contracts;
    using ReviewMuse.Web.Models.ExportModels;
    using static Common.ToastrMessages;
    using static ReviewMuse.Common.GeneralConstants;

    public class BookController : BaseController
    {
        private readonly IBookService bookService;
        private readonly ICategoryService categoryService;
        private readonly IReviewService reviewService;

        public BookController(IBookService bookService, ICategoryService categoryService, IReviewService reviewService)
        {
            this.bookService = bookService;
            this.categoryService = categoryService;
            this.reviewService = reviewService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AllBooks([FromQuery] ExpoAllBooksQueryViewModel queryModel)
        {
            try
            {
                var serviceModel = await this.bookService.AllAsync(queryModel);

                queryModel.Books = serviceModel.Books;
                queryModel.TotalBooks = serviceModel.TotalBooksCount;
                queryModel.Categories = await this.categoryService.AllCategoriesAsync();


                return View(queryModel);
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = generalErrorConst;

                return RedirectToAction("Index", "Home");
            }

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetBookById(string id)
        {
            try
            {

                bool bookExists = await this.bookService.BookExistsById(id);

                if (!bookExists)
                {
                    TempData["ErrorMessage"] = "The book you selected does not exist in our library!";

                    return RedirectToAction("AllBooks", "Book");
                }

                ExpoSingleBookViewModel model = await this.bookService.GetBookByIdAsync(id);

                bool bookHasReviews = await this.reviewService.BookHasReviewsAsync(model.BookId!);

                if (bookHasReviews)
                {
                    model.BookReviews = await this.reviewService.GetAllReviewsAsync(model.BookId!);
                }

                return View(model);

            }
            catch (Exception)
            {

                TempData["ErrorMessage"] = generalErrorConst;

                return RedirectToAction("Index", "Home");
            }

        }

    }
}

