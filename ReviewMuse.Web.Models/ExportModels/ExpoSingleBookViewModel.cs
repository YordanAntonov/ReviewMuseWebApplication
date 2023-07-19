namespace ReviewMuse.Web.Models.ExportModels
{
    public class ExpoSingleBookViewModel
    {
        public ExpoSingleBookViewModel()
        {
            this.AuthorsNames = new HashSet<ExpoPartialAuthorViewModel>();
            this.CategoriesNames = new HashSet<ExpoCategoryViewModel>();
        }
        public string BookId { get; set; } = null!;

        public string Title { get; set; } = null!;

        public int TotalRating { get; set; }


        public IEnumerable<ExpoPartialAuthorViewModel> AuthorsNames = null!;

        public IEnumerable<ExpoCategoryViewModel> CategoriesNames = null!;

        public string Description { get; set; } = null!;

        public int PagesCount { get; set; }

        public string CoverType { get; set; } = null!;

        public string PublishingDate { get; set; } = null!;

        public string ISBN { get; set; } = null!;

        public string Language { get; set; } = null!;

        public string? ImageUrl { get; set; }
    }
}
