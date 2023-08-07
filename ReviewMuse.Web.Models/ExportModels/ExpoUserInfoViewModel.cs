namespace ReviewMuse.Web.Models.ExportModels
{
    public class ExpoUserInfoViewModel
    {
        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int CountOfBookReviews { get; set; }

        public int TotalStars { get; set; }
    }
}
