namespace ReviewMuse.Web.Models.ImportModels
{
    using System.ComponentModel.DataAnnotations;
    using static ReviewMuse.Common.EntityValidationConstraints.Category;
    public class ImpoNewCategoryViewModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        [Display(Name = "Category Description")]
        public string Description { get; set; } = null!;
    }
}
