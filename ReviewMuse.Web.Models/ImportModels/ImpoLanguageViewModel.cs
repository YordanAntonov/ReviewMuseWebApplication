namespace ReviewMuse.Web.Models.ImportModels
{
    using System.ComponentModel.DataAnnotations;

    using static ReviewMuse.Common.EntityValidationConstraints.Language;

    public class ImpoLanguageViewModel
    {
        public int LanguageId { get; set; }

        [Required]
        [StringLength(LanguageNameMaxLength, MinimumLength = LanguageNameMinLength)]
        [Display(Name = "Language")]
        public string LanguageName { get; set; } = null!;
    }
}
