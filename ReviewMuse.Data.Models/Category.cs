namespace ReviewMuse.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static ReviewMuse.Common.EntityValidationConstraints.Category;

    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string CategoryName { get; set; } = null!;
    }
}
