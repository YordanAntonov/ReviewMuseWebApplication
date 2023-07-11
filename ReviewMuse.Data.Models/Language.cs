namespace ReviewMuse.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static ReviewMuse.Common.EntityValidationConstraints.Language;
    public class Language
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(LanguageNameMaxLength)]
        public string LanguageName { get; set; } = null!;
    }
}
