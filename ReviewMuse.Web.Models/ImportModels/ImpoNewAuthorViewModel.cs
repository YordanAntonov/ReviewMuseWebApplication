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

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        [Display(Name = "Author Full Name")]
        public string FullName { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        [Display(Name = "Short Biography")]
        public string Description { get; set; } = null!;

        [Required]
        public string DateOfBirth { get; set; } = null!;

        public string? DateOfDeath { get; set; }

        [Display(Name = "Website of the author")]
        public string? Website { get; set; }

        [Display(Name = "Image Url for author picture")]
        public string? ImageUrl { get; set; }

        [Required]
        [StringLength(CityNameMaxLength, MinimumLength = CityNameMinLength)]
        [Display(Name = "City Name")]
        public string CityName { get; set; } = null!;

        [Required]
        [StringLength(CountryNameMaxLength, MinimumLength = CountryNameMinLength)]
        [Display(Name = "Country Name")]
        public string CountryName { get; set; } = null!;

        [Display(Name = "Pseudonim of the Author")]
        public string? Pseudonim { get; set; }

        public IEnumerable<int> GanresId { get; set; } = null!;

        [Display(Name = "Ganres of the Author")]
        public IEnumerable<ImpoCategoriesForBookAndAuthorViewModel> Ganres = null!;
    }
}
