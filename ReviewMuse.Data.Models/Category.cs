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
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string CategoryName { get; set; } = null!;

        public virtual ICollection<CategoriesBooks> BooksCategories { get; set; } = null!;

        //We need collection for AuthorsBooks...
    }
}
