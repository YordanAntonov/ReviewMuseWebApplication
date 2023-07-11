namespace ReviewMuse.Data.Models.MappingTables
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CategoriesAuthors
    {
        [ForeignKey(nameof(Author))]
        public Guid AuthorId { get; set; }

        [Required]
        public virtual Author Author { get; set; } = null!;

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        [Required]
        public virtual Category Category { get; set; } = null!;
    }
}
