namespace ReviewMuse.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using ReviewMuse.Services.Contracts;
    using ReviewMuse.Web.Infrastructure.Extensions;
    using ReviewMuse.Web.Models.ExportModels;
    using ReviewMuse.Web.Models.ImportModels;

    public class AuthorController : BaseController
    {
        private readonly ICategoryService categoryService;
        private readonly IAuthorService authorService;
        private readonly IEditorService editorService;

        public AuthorController(IAuthorService authorService, IEditorService editorService, ICategoryService categoryService)
        {
            this.authorService = authorService;
            this.editorService = editorService;
            this.categoryService = categoryService;

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAuthorById(string id)
        {
            bool idIsValid = await this.authorService
                .AuthorExistByIdAsync(id);

            if (!idIsValid)
            {
                TempData["ErrorMessage"] = "The selected author does not exist in out system yet!";

                return RedirectToAction("Index", "Home");

                //Change later to All Authors
            }

            ExpoAuthorPageViewModel model = await this.authorService.GetAuthorByIdAsync(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthorsForAddingBook()
        {
            string userId = this.User.GetId();

            bool isEditor = await this.editorService.IsUserEditorById(Guid.Parse(userId));

            if (!isEditor)
            {
                TempData["ErrorMessage"] = "Access Denied! You must be an editor in order to access this page!";

                return RedirectToAction("Index", "Home");
            }

            IEnumerable<ExpoAuthorForAddingNewBookView> model = await this.authorService
                .GetAuthorForAddingBookAsync();

            return View(model);
        }

    }
}
