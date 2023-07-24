namespace ReviewMuse.Web.Models.ExportModels
{
    public class ExpoPartialBookViewModel
    {
        public ExpoPartialBookViewModel()
        {
            this.AuthorNames = new HashSet<string>();
        }

        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public IEnumerable<string> AuthorNames { get; set; } = null!;

        public string? ImageUrl { get; set; }

    }
}
