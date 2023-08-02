namespace ReviewMuse.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ReviewMuse.Services.Contracts;
    using ReviewMuse.Web.Infrastructure.Extensions;
    using ReviewMuse.Web.Models.ExportModels;
    using ReviewMuse.Web.Models.ImportModels;

    public class CategoriesController : BaseController
    {
        private readonly ICategoryService categoryService;
        private readonly IEditorService editorService;

        public CategoriesController(ICategoryService categoryService, IEditorService editorService)
        {
            this.categoryService = categoryService;
            this.editorService = editorService;

        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            bool categoryExist = await this.categoryService
                .CategoryExistByIdAsync(id);

            if (!categoryExist)
            {
                TempData["ErrorMessage"] = "The Category you selected does not exist!";

                return RedirectToAction("AllBooks", "Book");
            }

            ExpoCategoryViewModel model = await this.categoryService
                .GetCategoryByIdAsync(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddCategory()
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

        public async Task<IActionResult> AddCategory(ImpoNewCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Invalid Category input!";

                return View(model);
            }

            await this.categoryService.AddCategoryAsync(model);

            TempData["SuccessMessage"] = "Succesfully added new Ganre!";

            return RedirectToAction("GetAuthorsForAddingBook", "Author");
        }
    }
}
