namespace ReviewMuse.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using ReviewMuse.Services.Contracts;
    using ReviewMuse.Web.Models.ExportModels;

    using static Common.ToastrMessages;

    public class BookController : BaseController
    {
        private readonly IBookService bookService;
        private readonly ICategoryService categoryService;

        public BookController(IBookService bookService, ICategoryService categoryService)
        {
            this.bookService = bookService;
            this.categoryService = categoryService;

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AllBooks([FromQuery]ExpoAllBooksQueryViewModel queryModel)
        {
            var serviceModel = await this.bookService.AllAsync(queryModel);

            queryModel.Books = serviceModel.Books;
            queryModel.TotalBooks = serviceModel.TotalBooksCount;
            queryModel.Categories = await this.categoryService.AllCategoriesAsync();

            return View(queryModel);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetBookById(string id)
        {
            bool bookExists = await this.bookService.BookExistsById(id);

            if (!bookExists)
            {
                TempData["ErrorMessage"] = "The book you selected does not exist in our library!";

                return RedirectToAction("AllBooks", "Book");
            }

            ExpoSingleBookViewModel model = await this.bookService.GetBookByIdAsync(id);

            return View(model);
        }
    }
}
