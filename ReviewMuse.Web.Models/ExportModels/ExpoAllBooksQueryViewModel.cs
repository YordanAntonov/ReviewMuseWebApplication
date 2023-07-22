namespace ReviewMuse.Web.Models.ExportModels
{

    using System.ComponentModel.DataAnnotations;

    using ReviewMuse.Web.Models.ExportModels.Enums;

    using static ReviewMuse.Common.GeneralConstants;

    public class ExpoAllBooksQueryViewModel
    {
        public ExpoAllBooksQueryViewModel()
        {
            this.BooksPerPage = DefBooksPerPage;
            this.CurrentPage = DefStartPage;

            this.Categories = new HashSet<string>();  
            this.Books = new HashSet<ExpoAllBooksViewModel>();
        }

        public string? Category { get; set; }

        [Display(Name = "Search")]
        public string? SearchQuery { get; set; }

        [Display(Name = "Sort By")]
        public  BookSorting BookSorting { get; set; }

        public int CurrentPage { get; set; }

        [Display(Name= "Books per page")]
        public int BooksPerPage { get; set; }

        public int TotalBooks { get; set; }

        public IEnumerable<string> Categories { get; set; } = null!;

        public IEnumerable<ExpoAllBooksViewModel> Books { get; set; } = null!;
    }
}
