namespace ReviewMuse.Web.Models.ImportModels
{
    using System.ComponentModel.DataAnnotations;

    using static ReviewMuse.Common.EntityValidationConstraints.Author;

    public class ImpoNewAuthorViewModel
    {
        public ImpoNewAuthorViewModel()
        {
            this.Ganres = new HashSet<ImpoCategoriesForBookAndAuthorViewModel>();
            this.GanresId = new HashSet<int>();
        }

        public string? AuthorId { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        [Display(Name = "Author Full Name")]
        public string FullName { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        [Display(Name = "Short Biography")]
        public string Description { get; set; } = null!;

        [Required]
        [RegularExpression(@"^\d{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2]\d|3[0-1])$", ErrorMessage = "Invalid date format. Use 'yyyy-MM-dd' format.")]
        public string DateOfBirth { get; set; } = null!;

        [RegularExpression(@"^\d{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2]\d|3[0-1])$", ErrorMessage = "Invalid date format. Use yyyy-MM-dd.")]
        public string? DateOfDeath { get; set; }

        [Display(Name = "Website of the author")]
        public string? Website { get; set; }

        [Display(Name = "Image Url for author picture")]
        public string? ImageUrl { get; set; }

        [Required]
        [StringLength(CityNameMaxLength, MinimumLength = CityNameMinLength, ErrorMessage = "City Name is Required!")]
        [Display(Name = "City Name")]
        public string CityName { get; set; } = null!;

        [Required]
        [StringLength(CountryNameMaxLength, MinimumLength = CountryNameMinLength, ErrorMessage = "Country Name is Required!")]
        [Display(Name = "Country Name")]
        public string CountryName { get; set; } = null!;

        [Display(Name = "Pseudonim of the Author")]
        public string? Pseudonim { get; set; }

        public IEnumerable<int>? GanresId { get; set; }

        [Display(Name = "Ganres of the Author")]
        public IEnumerable<ImpoCategoriesForBookAndAuthorViewModel>? Ganres { get; set; }
    }
}
