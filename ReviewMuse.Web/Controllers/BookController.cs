using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReviewMuse.Services.Contracts;
using ReviewMuse.Web.Models.ExportModels;

namespace ReviewMuse.Web.Controllers
{
    public class BookController : BaseController
    {
        private readonly IBookService bookService;
        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AllBooks()
        {
            IEnumerable<ExpoAllBooksViewModel> model = await this.bookService.GetAllBooksAsync();
           

            return View(model);
        }
    }
}
