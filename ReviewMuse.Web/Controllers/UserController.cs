namespace ReviewMuse.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ReviewMuse.Services.Contracts;
    using ReviewMuse.Web.Infrastructure.Extensions;
    using ReviewMuse.Web.Models.ExportModels;
    using static ReviewMuse.Common.GeneralConstants;

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
            try
            {
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
            catch (Exception)
            {
                TempData["ErrorMessage"] = generalErrorConst;

                return RedirectToAction("Index", "Home");
            }

        }

        public async Task<IActionResult> UpdateFavouriteBook(ExpoSingleBookViewModel model)
        {
            try
            {
                bool bookExists = await this.bookService.BookExistsById(model.BookId!);

                if (!bookExists)
                {
                    TempData["ErrorMessage"] = "The book you selected does not exist in our library!";

                    return RedirectToAction("AllBooks", "Book");
                }

                string? id = model.BookId;

                string userId = this.User.GetId();

                await this.userService.UpdateToCollectionBookAsync(model, userId);

                TempData["SuccessMessage"] = "Succesfully updated the status of the book!";

                return RedirectToAction("GetBookById", "Book", new { id = id });

            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = generalErrorConst;

                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> MyBooks([FromQuery] ExpoMyBooksCollectionQueryModel queryModel)
        {
            try
            {
                string userId = this.User.GetId();

                var serviceModel = await this.userService.MyCollectionAsync(queryModel, userId);

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

        public async Task<IActionResult> RemoveFromFavourites(string id)
        {
            try
            {
                bool idIsValid = await this.bookService.BookExistsById(id);

                if (!idIsValid)
                {
                    TempData["ErrorMessage"] = "Selected Book does not exist!";

                    return RedirectToAction("MyBooks", "User");
                }

                string userId = this.User.GetId();

                await this.userService.RemoveFromFavouritesAsync(id, userId);

                TempData["InfoMessage"] = "Book removed from your Library!";

                return RedirectToAction("MyBooks", "User");

            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = generalErrorConst;

                return RedirectToAction("Index", "Home");
            }
        }
    }
}
