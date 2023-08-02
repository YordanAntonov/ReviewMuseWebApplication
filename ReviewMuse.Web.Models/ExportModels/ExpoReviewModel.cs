namespace ReviewMuse.Web.Models.ExportModels
{
    public class ExpoReviewModel
    {
        public string Id { get; set; } = null!;
        public string? Username { get; set; }
        public int Rating { get; set; }
        public string? DatePublished { get; set; }
        public string? Comment { get; set; }
    }
}
