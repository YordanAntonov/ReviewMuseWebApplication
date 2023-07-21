namespace ReviewMuse.Web.Models.ExportModels
{
    using ReviewMuse.Web.Models.ImportModels; 

    public class ExpoSingleBookViewModel
    {
        public ExpoSingleBookViewModel()
        {
            this.AuthorsNames = new HashSet<ExpoPartialAuthorViewModel>();
            this.CategoriesNames = new HashSet<ExpoCategoryViewModel>();
            this.BookReviews = new HashSet<ExpoReviewModel>();
            this.UserReview = new ImpoReviewModel();
        }
        public string? BookId { get; set; }

        public string? Title { get; set; }

        public int TotalRating { get; set; }

        public ImpoReviewModel UserReview { get; set; } = null!;

        public IEnumerable<ExpoPartialAuthorViewModel> AuthorsNames = null!;

        public IEnumerable<ExpoCategoryViewModel> CategoriesNames = null!;

        public IEnumerable<ExpoReviewModel> BookReviews = null!;

        public string? Description { get; set; }

        public int PagesCount { get; set; }

        public string? CoverType { get; set; }

        public string? PublishingDate { get; set; }
        public string? ISBN { get; set; }

        public string? Language { get; set; }

        public string? ImageUrl { get; set; }
    }
}
