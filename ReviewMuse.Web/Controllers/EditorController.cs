namespace ReviewMuse.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using ReviewMuse.Services.Contracts;
    using ReviewMuse.Web.Infrastructure.Extensions;
    using ReviewMuse.Web.Models.ImportModels;

    public class EditorController : BaseController
    {
        private readonly ICategoryService categoryService;
        private readonly IAuthorService authorService;
        private readonly IEditorService editorService;
        private readonly IBookService bookService;

        public EditorController(IAuthorService authorService, IEditorService editorService, ICategoryService categoryService, IBookService bookService)
        {
            this.authorService = authorService;
            this.editorService = editorService;
            this.categoryService = categoryService;
            this.bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> AddAuthor()
        {
            string userId = this.User.GetId();

            bool isEditor = await this.editorService.IsUserEditorById(Guid.Parse(userId));

            if (!isEditor)
            {
                TempData["ErrorMessage"] = "Access Denied! You must be an editor in order to access this page!";

                return RedirectToAction("Index", "Home");
            }

            ImpoNewAuthorViewModel model = new ImpoNewAuthorViewModel();

            model.Ganres = await this.categoryService.GetCategoriesAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor(ImpoNewAuthorViewModel model)
        {
            string userId = this.User.GetId();

            bool isEditor = await this.editorService.IsUserEditorById(Guid.Parse(userId));

            if (!isEditor)
            {
                TempData["ErrorMessage"] = "Access Denied! You must be an editor in order to access this page!";

                return RedirectToAction("Index", "Home");
            }

            bool idInvalid = false;

            foreach (var id in model.GanresId)
            {
                if (!await this.categoryService.CategoryExistByIdAsync(id))
                {
                    idInvalid = true;
                }

                if (idInvalid)
                {
                    TempData["ErrorMessage"] = "Submitted invalid Category!";
                    model.Ganres = await this.categoryService.GetCategoriesAsync();
                    return View(model);
                }

            }
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Submition Invalid!";
                model.Ganres = await this.categoryService.GetCategoriesAsync();
                return View(model);
            }

            await this.authorService.AddAuthorAsync(model);

            TempData["SuccessMessage"] = "Succesfully added an new Author!";

            return RedirectToAction("GetAuthorsForAddingBook", "Author");
        }

        [HttpGet]
        public async Task<IActionResult> AddBook(string id)
        {
            ImpoNewBookViewModel model = new ImpoNewBookViewModel();

            bool authorExists = await this.authorService.AuthorExistByIdAsync(id);

            if (!authorExists)
            {
                TempData["ErrorMessage"] = "Author with this id does not exist";

                return RedirectToAction("GetAuthorsForAddingBook", "Author");
            }

            model.AuthorId = id;
            model.BookCovers = await this.bookService.GetBookCoversAsync();
            model.Languages = await this.bookService.GetBookLanguagesAsync();
            model.Ganres = await this.categoryService.GetCategoriesAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(ImpoNewBookViewModel model)
        {
            string userId = this.User.GetId();

            bool isEditor = await this.editorService.IsUserEditorById(Guid.Parse(userId));

            if (!isEditor)
            {
                TempData["ErrorMessage"] = "Access Denied! You must be an editor in order to access this page!";

                return RedirectToAction("Index", "Home");
            }

            bool idInvalid = false;

            foreach (var id in model.GanresId)
            {
                if (!await this.categoryService.CategoryExistByIdAsync(id))
                {
                    idInvalid = true;
                }

                if (idInvalid)
                {
                    TempData["ErrorMessage"] = "Submitted invalid Category!";
                    model.Ganres = await this.categoryService.GetCategoriesAsync();
                    return View(model);
                }

            }

            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Submition Invalid!";

                model.BookCovers = await this.bookService.GetBookCoversAsync();
                model.Languages = await this.bookService.GetBookLanguagesAsync();
                model.Ganres = await this.categoryService.GetCategoriesAsync();

                return View(model);
            }

            string editorId = await this.editorService.GetEditorIdViaUserIdAsync(Guid.Parse(userId));

            await this.bookService.AddBook(model, editorId);

            TempData["SuccessMessage"] = "Succesfully Added new Book!";

            return RedirectToAction("GetAuthorById", "Author", new { id = model.AuthorId });
        }


        [HttpGet]
        public async Task<IActionResult> AddLanguage()
        {
            string userId = this.User.GetId();

            bool isEditor = await this.editorService.IsUserEditorById(Guid.Parse(userId));
            if (!isEditor)
            {
                TempData["ErrorMessage"] = "Access Denied! You must be an editor in order to access this page!";

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddLanguage(ImpoLanguageViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Invalid Language!";

                return View(model);
            }


            await this.editorService.AddNewLanguage(model);

            TempData["SuccessMessage"] = "Succesfully added new Language!";

            return RedirectToAction("GetAuthorsForAddingBook", "Author");
        }
    }
}
