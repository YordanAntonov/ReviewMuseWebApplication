namespace ReviewMuse.Web.Models.ImportModels
{
    using System.ComponentModel.DataAnnotations;

    using static ReviewMuse.Common.EntityValidationConstraints.BookCoverType;

    public class ImpoCoverTypeViewModel
    {
        public int CoverId { get; set; }

        [Required]
        [StringLength(TypeNameMaxLength, MinimumLength = TypeNameMinLength)]
        [Display(Name = "Cover Type")]
        public string CoverName { get; set; } = null!;
    }
}
