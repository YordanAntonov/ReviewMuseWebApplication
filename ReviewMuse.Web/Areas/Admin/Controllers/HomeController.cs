namespace ReviewMuse.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using ReviewMuse.Data.Models;
    using ReviewMuse.Services.Contracts;
    using ReviewMuse.Web.Areas.Admin.ViewModels;
    using ReviewMuse.Web.Infrastructure.Extensions;
    using ReviewMuse.Web.Models.ImportModels;
    using static ReviewMuse.Common.GeneralConstants;

    public class HomeController : BaseAdminController
    {
        private readonly IEditorService editorService;
        private readonly IUserService userService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole<Guid>> roleManager;

        public HomeController(IEditorService editorService, IUserService userService, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<Guid>> roleManager)
        {
            this.editorService = editorService;
            this.userService = userService;
            this.userManager = userManager;
            this.roleManager = roleManager;

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BecomeEditor()
        {
            try
            {
                bool isUserEditor = await this.editorService.IsUserEditorById(Guid.Parse(User.GetId()));
                if (!isUserEditor)
                {
                    TempData["ErrorMessage"] = "You are already an Editor!";

                    return RedirectToAction("Index", "Home", new { area = AdminAreaName });
                }

                ImpoNewEditorViewModel model = new ImpoNewEditorViewModel()
                {
                    UserId = this.User.GetId(),
                    PhoneNumber = "0888888889",
                    DateOfBirth = "9999-12-12"
                };

                await this.editorService.BecomeEditorAsync(model);

                TempData["SuccessMessage"] = "Succesfully set yourself as an Editor!";

                return RedirectToAction("Index", "Home", new { area = AdminAreaName });

            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = generalErrorConst;

                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> AllUsers()
        {
            try
            {
                IEnumerable<ExpoAllUsersViewModel> model = await this.userService.AllUsersAsync();

                foreach (var user in model)
                {
                    bool isEditor = await this.editorService.IsUserEditorById(Guid.Parse(user.UserId));
                    var users = await userManager.FindByIdAsync(user.UserId);

                    bool userIsAdmin = await userManager.IsInRoleAsync(users, AdminRoleName);

                    if (isEditor)
                    {
                        user.IsEditor = true;
                    }

                    if (userIsAdmin)
                    {
                        user.IsAdmin = true;
                    }
                }

                return View(model);

            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = generalErrorConst;

                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveAccount(string userId)
        {
            try
            {
                bool isUserEditor = await this.editorService.IsUserEditorByIdNonActive(Guid.Parse(userId));

                await this.userService.RemoveUserAsync(userId, isUserEditor);

                TempData["SuccessMessage"] = "Succesfully Removed the account! Click Log Out Otherwise you wont be able to do anything!";

                return RedirectToAction("Index", "Home", new { area = "" });
            }
            catch (Exception)
            {

                TempData["ErrorMessage"] = generalErrorConst;

                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> PromoteToAdmin(string userId)
        {
            try
            {
                ApplicationUser user = await userManager.FindByIdAsync(userId);

                if (user == null)
                {
                    return NotFound();
                }

                string adminRoleName = AdminRoleName;
                bool roleExists = await roleManager.RoleExistsAsync(adminRoleName);

                await userManager.AddToRoleAsync(user, adminRoleName);


                return RedirectToAction("AllUsers", "Home");
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = generalErrorConst;

                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveEditor(string userId)
        {
            try
            {
                await this.editorService.RemoveEditor(userId);

                return RedirectToAction("AllUsers", "Home");
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = generalErrorConst;

                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }
    }
}
