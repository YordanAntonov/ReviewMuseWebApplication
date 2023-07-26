namespace ReviewMuse.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ReviewMuse.Services.Contracts;
    using ReviewMuse.Web.Infrastructure.Extensions;
    using ReviewMuse.Web.Models.ExportModels;

    public class UserController : BaseController
    {
        private readonly IBookService bookService;
        private readonly IUserService userService;
        private readonly ICategoryService categoryService;

        public UserController(IBookService bookService, IUserService userService, ICategoryService categoryService)
        {
            this.bookService = bookService;
            this.userService = userService;
            this.categoryService = categoryService;
        }

        public async Task<IActionResult> AddToFavourites(ExpoSingleBookViewModel model)
        {
            //Implement functionality for userService which checks if the user have already added this book to favourites, if yes and he submits different
            //bookStatus, update it, if he tries to submit the same status send back error message or do not give him to click the button!

            bool bookExists = await this.bookService.BookExistsById(model.BookId!);

            if (!bookExists)
            {
                TempData["ErrorMessage"] = "The book you selected does not exist in our library!";

                return RedirectToAction("AllBooks", "Book");
            }

            string? id = model.BookId;

            string userId = this.User.GetId();

            await this.userService.AddToCollectionAsync(model, userId);

            TempData["SuccessMessage"] = "Succesfully added this book to your collection!";

            return RedirectToAction("GetBookById", "Book", new { id = id });
        }

        public async Task<IActionResult> MyBooks([FromQuery] ExpoMyBooksCollectionQueryModel queryModel)
        {
            string userId = this.User.GetId();

            var serviceModel = await this.userService.MyCollectionAsync(queryModel, userId);

            queryModel.Books = serviceModel.Books;
            queryModel.TotalBooks = serviceModel.TotalBooksCount;
            queryModel.Categories = await this.categoryService.AllCategoriesAsync();

            return View(queryModel);
        }
    }
}
