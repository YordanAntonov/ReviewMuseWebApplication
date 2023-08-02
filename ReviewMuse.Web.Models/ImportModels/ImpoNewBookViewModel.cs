namespace ReviewMuse.Web.Models.ImportModels
{
    using System.ComponentModel.DataAnnotations;

    using static ReviewMuse.Common.EntityValidationConstraints.Book;

    public class ImpoNewBookViewModel
    {
        public ImpoNewBookViewModel()
        {
            this.BookCovers = new HashSet<ImpoCoverTypeViewModel>();
            this.Languages = new HashSet<ImpoLanguageViewModel>();
        }
        public string AuthorId { get; set; } = null!;

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        [Display(Name = "Book Title")]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        [Display(Name = "Short Description")]
        public string Description { get; set; } = null!;

        [Required]
        [RegularExpression(@"^\d{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2]\d|3[0-1])$", ErrorMessage = "Invalid date format. Use 'yyyy-MM-dd' format.")]
        [Display(Name = "Date of publishing")]
        public string PublishingDate { get; set; } = null!;

        [Required]
        public string? ImageUrl { get; set; } = null!;

        [Required]
        [Range(1, int.MaxValue)]
        public int NumberOfPages { get; set; }

        [Required]
        [StringLength(BookIsbnSize)]
        public string ISBN { get; set; } = null!;

        public string? AmazonLink { get; set; }

        [Required]
        public int CoverId { get; set; }

        public IEnumerable<ImpoCoverTypeViewModel> BookCovers { get; set; } = null!;

        [Required]
        public int LanguageId { get; set; }

        public IEnumerable<ImpoLanguageViewModel> Languages { get; set; }

        [Required]
        public IEnumerable<int> GanresId { get; set; } = null!;

        [Display(Name = "Ganres of the Book")]
        public IEnumerable<ImpoCategoriesForBookAndAuthorViewModel> Ganres = null!;
    }
}
