namespace ReviewMuse.Data.Models.MappingTables
{

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UsersBooks
    {
        [ForeignKey(nameof(ApplicationUser))]
        public Guid ApplicationUserId { get; set; }

        [Required]
        public virtual ApplicationUser ApplicationUser { get; set; } = null!;

        [ForeignKey(nameof(Book))]
        public Guid BookId { get; set; }

        [Required]
        public virtual Book Book { get; set; } = null!;

        [ForeignKey(nameof(BookStatus))]
        public int BookStatusId { get; set; }

        [Required]
        public virtual BookStatus BookStatus { get; set; } = null!;
    }
}
