namespace ReviewMuse.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ReviewMuse.Services.Contracts;
    using ReviewMuse.Web.Models.ExportModels;

    public class CategoriesController : BaseController
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
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
    }
}
