namespace ReviewMuse.Web.Models.ExportModels
{

    using System.ComponentModel.DataAnnotations;

    public class ExpoAllBooksViewModel
    {
        public string BookId { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string? ImageUrl { get; set; }

        public IEnumerable<GetAuthorView> AuthorsNames = null!;

        public int BookRating { get; set; }

        [Display(Name = "Publishing Date")]
        public string PublishedDate { get; set; } = null!;

    }
}
