namespace ReviewMuse.Data.Models
{
    using ReviewMuse.Data.Models.MappingTables;
    using System.ComponentModel.DataAnnotations;

    using static ReviewMuse.Common.EntityValidationConstraints.Category;

    public class Category
    {
        public Category()
        {
            this.BooksCategories = new HashSet<CategoriesBooks>();
            this.AuthorsCategory = new HashSet<CategoriesAuthors>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string CategoryName { get; set; } = null!;

        [Required]
        [MaxLength]
        public string Description { get; set; } = null!;

        public virtual ICollection<CategoriesBooks> BooksCategories { get; set; } = null!;

        public virtual ICollection<CategoriesAuthors> AuthorsCategory { get; set; } = null!;
    }
}
