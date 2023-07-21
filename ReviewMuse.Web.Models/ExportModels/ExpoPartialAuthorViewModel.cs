namespace ReviewMuse.Web.Models.ExportModels
{
    public class ExpoPartialAuthorViewModel
    {
        //The nullable types can be used in partial view for "More about the author" partial view!
        public string? AuthorId { get; set; }

        public string? AuthorPseudonim { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public string? BirthDate { get; set; }

        public int? BooksCount { get; set; }
    }
}
