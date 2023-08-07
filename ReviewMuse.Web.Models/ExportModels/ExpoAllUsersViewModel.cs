namespace ReviewMuse.Web.Areas.Admin.ViewModels
{
    public class ExpoAllUsersViewModel
    {
        public string UserId { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public bool IsEditor { get; set; } = false;

        public bool IsAdmin { get; set; } = false;
    }
}
