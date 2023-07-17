namespace ReviewMuse.Web.Models.ExportModels
{
    public class ExpoAllBooksViewModel
    {
        public string BookId { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string? ImageUrl { get; set; }

        public IEnumerable<string> AuthorsNames = null!;
        public int BookRating { get; set; }
        public string PublishedDate { get; set; } = null!;

    }
}
