namespace ReviewMuse.Web.Models.ExportModels
{
    using ReviewMuse.Web.Models.ExportModels.Enums;
    using System.ComponentModel.DataAnnotations;

    using static ReviewMuse.Common.GeneralConstants;

    public class ExpoMyBooksCollectionQueryModel
    {
        public ExpoMyBooksCollectionQueryModel()
        {
            this.BooksPerPage = DefBooksPerPage;
            this.CurrentPage = DefStartPage;

            this.Categories = new HashSet<string>();
            this.Books = new HashSet<ExpoMyBooksCollectionView>();
        }

        public string? Category { get; set; }

        [Display(Name = "Search")]
        public string? SearchQuery { get; set; }

        [Display(Name = "Sort By")]
        public BookSorting BookSorting { get; set; }

        public int CurrentPage { get; set; }

        [Display(Name = "Books per page")]
        public int BooksPerPage { get; set; }

        public int TotalBooks { get; set; }

        public IEnumerable<string> Categories { get; set; } = null!;

        public IEnumerable<ExpoMyBooksCollectionView> Books { get; set; } = null!;
    }
}
