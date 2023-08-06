namespace ReviewMuse.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using ReviewMuse.Services.Contracts;
    using ReviewMuse.Web.Infrastructure.Extensions;
    using ReviewMuse.Web.Models.ImportModels;
    using Stripe;
    using Stripe.Checkout;
    using System.Security.Claims;

    using static ReviewMuse.Common.GeneralConstants;

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
            try
            {
                string userId = this.User.GetId();

                bool isEditor = await this.editorService.IsUserEditorById(Guid.Parse(userId));

                bool isAdmin = this.User.IsAdmin();

                if (!isEditor && !isAdmin)
                {
                    TempData["ErrorMessage"] = "Access Denied! You must be an editor in order to access this page!";

                    return RedirectToAction("Index", "Home");
                }

                ImpoNewAuthorViewModel model = new ImpoNewAuthorViewModel();

                model.Ganres = await this.categoryService.GetCategoriesAsync();

                return View(model);

            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = generalErrorConst;

                return RedirectToAction("Index", "Home");
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor(ImpoNewAuthorViewModel model)
        {
            try
            {
                string userId = this.User.GetId();

                bool isEditor = await this.editorService.IsUserEditorById(Guid.Parse(userId));
                bool isAdmin = this.User.IsAdmin();

                if (!isEditor && !isAdmin)
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
            catch (Exception)
            {
                TempData["ErrorMessage"] = generalErrorConst;

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> AddBook(string id)
        {
            ImpoNewBookViewModel model = new ImpoNewBookViewModel();

            try
            {
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
            catch (Exception)
            {
                TempData["ErrorMessage"] = generalErrorConst;

                return RedirectToAction("Index", "Home");
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddBook(ImpoNewBookViewModel model)
        {
            try
            {
                string userId = this.User.GetId();

                bool isAdmin = this.User.IsAdmin();
                bool isEditor = await this.editorService.IsUserEditorById(Guid.Parse(userId));

                if (!isEditor && !isAdmin)
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
            catch (Exception)
            {
                TempData["ErrorMessage"] = generalErrorConst;

                return RedirectToAction("Index", "Home");
            }
        }


        [HttpGet]
        public async Task<IActionResult> AddLanguage()
        {
            try
            {
                string userId = this.User.GetId();
                bool isAdmin = this.User.IsAdmin();

                bool isEditor = await this.editorService.IsUserEditorById(Guid.Parse(userId));
                if (!isEditor && !isAdmin)
                {
                    TempData["ErrorMessage"] = "Access Denied! You must be an editor in order to access this page!";

                    return RedirectToAction("Index", "Home");
                }

                return View();

            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = generalErrorConst;

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddLanguage(ImpoLanguageViewModel model)
        {
            try
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
            catch (Exception)
            {
                TempData["ErrorMessage"] = generalErrorConst;

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditBook(string id)
        {
            try
            {
                string userId = User.GetId();
                bool userIsEditor = await this.editorService.IsUserEditorById(Guid.Parse(userId));
                bool isAdmin = this.User.IsAdmin();

                if (!userIsEditor && !isAdmin)
                {
                    TempData["ErrorMessage"] = "Access Denied! You must be an editor in order to access this page!";

                    return RedirectToAction("Index", "Home");
                }

                string editorId = await this.editorService.GetEditorIdViaUserIdAsync(Guid.Parse(userId));

                bool bookIsValid = await this.bookService.BookExistsById(id);

                if (!bookIsValid)
                {
                    TempData["ErrorMessage"] = "The book you selected does not exist!";

                    return RedirectToAction("Index", "Home");
                }

                string bookEditorId = await this.bookService.GetBookEditorId(id);

                if (bookEditorId != editorId && !isAdmin)
                {
                    TempData["InfoMessage"] = "You are not the creator of this book! You can edit only books that you have added!";

                    return RedirectToAction("GetAuthorsForAddingBook", "Author");
                }

                ImpoNewBookViewModel model = await this.editorService.GetEditBookAsync(id);
                model.Ganres = await this.categoryService.GetCategoriesAsync();
                model.BookCovers = await this.bookService.GetBookCoversAsync();
                model.Languages = await this.bookService.GetBookLanguagesAsync();

                return View(model);

            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = generalErrorConst;

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditBook(ImpoNewBookViewModel model)
        {
            try
            {
                string userId = this.User.GetId();

                bool isEditor = await this.editorService.IsUserEditorById(Guid.Parse(userId));

                if (!isEditor)
                {
                    TempData["ErrorMessage"] = "Access Denied! You must be an editor in order to access this page!";

                    return RedirectToAction("Index", "Home");
                }

                if (!ModelState.IsValid)
                {
                    TempData["ErrorMessage"] = "Submition Invalid!";

                    model.BookCovers = await this.bookService.GetBookCoversAsync();
                    model.Languages = await this.bookService.GetBookLanguagesAsync();
                    model.Ganres = await this.categoryService.GetCategoriesAsync();

                    return View(model);
                }

                bool idInvalid = false;

                if (model.GanresId != null)
                {
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
                }

                await this.editorService.EditBookAsync(model);

                TempData["SuccessMessage"] = $"Successfully Edited {model.Title}!";

                return RedirectToAction("GetBookById", "Book", new { id = model.BookId });

            }
            catch (Exception)
            {

                TempData["ErrorMessage"] = generalErrorConst;

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditAuthor(string id)
        {
            try
            {
                string userId = User.GetId();
                bool userIsEditor = await this.editorService.IsUserEditorById(Guid.Parse(userId));

                if (!userIsEditor)
                {
                    TempData["ErrorMessage"] = "Access Denied! You must be an editor in order to access this page!";

                    return RedirectToAction("Index", "Home");
                }

                string editorId = await this.editorService.GetEditorIdViaUserIdAsync(Guid.Parse(userId));

                bool authorIsValid = await this.authorService.AuthorExistByIdAsync(id);

                if (!authorIsValid)
                {
                    TempData["ErrorMessage"] = "The author you selected does not exist!";

                    return RedirectToAction("Index", "Home");
                }

                ImpoNewAuthorViewModel model = await this.editorService.GetEditAuthorAsync(id);
                model.Ganres = await this.categoryService.GetCategoriesAsync();

                return View(model);

            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = generalErrorConst;

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditAuthor(ImpoNewAuthorViewModel model)
        {
            try
            {
                string userId = this.User.GetId();

                bool isEditor = await this.editorService.IsUserEditorById(Guid.Parse(userId));

                if (!isEditor)
                {
                    TempData["ErrorMessage"] = "Access Denied! You must be an editor in order to access this page!";

                    return RedirectToAction("Index", "Home");
                }

                if (!ModelState.IsValid)
                {
                    TempData["ErrorMessage"] = "Submition Invalid!";

                    model.Ganres = await this.categoryService.GetCategoriesAsync();

                    return View(model);
                }

                bool idInvalid = false;

                if (model.GanresId != null)
                {
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
                }

                await this.editorService.EditAuthorAsync(model);

                TempData["SuccessMessage"] = $"Successfully Edited {model.FullName}!";

                return RedirectToAction("GetAuthorById", "Author", new { id = model.AuthorId });

            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = generalErrorConst;

                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> BecomeEditor()
        {
            try
            {
                string userId = User.GetId();
                bool userIsEditor = await this.editorService.IsUserEditorById(Guid.Parse(userId));

                if (userIsEditor)
                {
                    TempData["WarningMessage"] = "Access Denied! You have already become an editor!";

                    return RedirectToAction("Index", "Home");
                }

                var domain = "https://localhost:7235/";

                var options = new SessionCreateOptions
                {
                    SuccessUrl = domain + $"Editor/FillDetails",
                    CancelUrl = domain + $"Home/Index",
                    LineItems = new List<SessionLineItemOptions>(),
                    Mode = "payment",
                    CustomerEmail = User.FindFirstValue(ClaimTypes.Email)
                };

                var sessionListItem = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = 20000,
                        Currency = "bgn",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = "One time Payment to join our Community of Editors in ReviewMuse."
                        }
                    },
                    Quantity = 1
                };

                options.LineItems.Add(sessionListItem);

                var service = new SessionService();
                Session session = service.Create(options);

                TempData["Session"] = session.Id;

                Response.Headers.Add("Location", session.Url);

                return new StatusCodeResult(303);

            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = generalErrorConst;

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> FillDetails()
        {
            try
            {
                string userId = User.GetId();
                bool userIsEditor = await this.editorService.IsUserEditorById(Guid.Parse(userId));

                if (userIsEditor)
                {
                    TempData["ErrorMessage"] = "Access Denied! You have already become an editor!";

                    return RedirectToAction("Index", "Home");
                }

                if (TempData["Session"] == null)
                {
                    TempData["ErrorMessage"] = "Unauthorized access! In order to access this page you have to pay to become Editor!";

                    return RedirectToAction("Index", "Home");
                }

                var service = new SessionService();
                Session session = service.Get(TempData["Session"].ToString());

                if (session.PaymentStatus == SessionPayedStatus)
                {
                    TempData["SuccessMessage"] = "Successfull Payment! Please continue with the next step.";

                    return View();
                }
                else
                {
                    TempData["ErrorMessage"] = "Unauthorized access! In order to access this page you have to pay to become Editor!";

                    return RedirectToAction("Index", "Home");
                }

            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = generalErrorConst;

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> RemoveBook(string id)
        {
            try
            {
                bool isAdmin = this.User.IsAdmin();
                string userId = User.GetId();
                bool userIsEditor = await this.editorService.IsUserEditorById(Guid.Parse(userId));


                if (!userIsEditor)
                {
                    TempData["ErrorMessage"] = "Access Denied! You must be an editor in order to access this page!";

                    return RedirectToAction("Index", "Home");
                }

                string editorId = await this.editorService.GetEditorIdViaUserIdAsync(Guid.Parse(userId));

                bool bookIsValid = await this.bookService.BookExistsById(id);

                if (!bookIsValid)
                {
                    TempData["ErrorMessage"] = "The book you selected does not exist!";

                    return RedirectToAction("AllBooks", "Book");
                }

                string bookEditorId = await this.bookService.GetBookEditorId(id);

                if (bookEditorId != editorId && !isAdmin)
                {
                    TempData["InfoMessage"] = "You are not the creator of this book! You can remove only books that you have added!";

                    return RedirectToAction("GetAuthorsForAddingBook", "Author");
                }

                await this.editorService.RemoveBookAsync(id);

                TempData["WarningMessage"] = "Succesfully Removed Book!";

                return RedirectToAction("AllBooks", "Book");
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = generalErrorConst;

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> FillDetails(ImpoNewEditorViewModel model)
        {
            try
            {
                string userId = User.GetId();
                bool userIsEditor = await this.editorService.IsUserEditorById(Guid.Parse(userId));

                if (userIsEditor)
                {
                    TempData["ErrorMessage"] = "Access Denied! You have already become an editor!";

                    return RedirectToAction("Index", "Home");
                }

                if (!ModelState.IsValid)
                {
                    TempData["ErrorMessage"] = "Submition Invalid!";

                    View(model);
                }

                model.UserId = userId;

                await this.editorService.BecomeEditorAsync(model);

                TempData["SuccessMessage"] = "Congratulations! You have become an Editor. Thank you for the support!";

                return RedirectToAction("Index", "Home");

            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = generalErrorConst;

                return RedirectToAction("Index", "Home");
            }
        }
    }
}
