namespace ReviewMuse.Data.Models.MappingTables
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class AuthorsBooks
    {
        [ForeignKey(nameof(Author))]
        public Guid AuthorId { get; set; }

        [Required]
        public virtual Author Author { get; set; } = null!;

        [ForeignKey(nameof(Book))]
        public Guid BookId { get; set; }

        [Required]
        public virtual Book Book { get; set; } = null!;
    }
}
