namespace ReviewMuse.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ReviewMuse.Services.Contracts;
    using ReviewMuse.Web.Models.ExportModels;

    public class AuthorController : BaseController
    {
        private readonly IAuthorService authorService;

        public AuthorController(IAuthorService authorService)
        {
            this.authorService = authorService;
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

    }
}
