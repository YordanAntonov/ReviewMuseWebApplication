namespace ReviewMuse.Data.Models.MappingTables
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class AuthorsBooks
    {
        public AuthorsBooks()
        {
            this.IsActive = true;
        }

        [ForeignKey(nameof(Author))]
        public Guid AuthorId { get; set; }

        [Required]
        public virtual Author Author { get; set; } = null!;

        [ForeignKey(nameof(Book))]
        public Guid BookId { get; set; }

        [Required]
        public virtual Book Book { get; set; } = null!;

        public bool IsActive { get; set; }
    }
}
