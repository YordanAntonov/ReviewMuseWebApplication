namespace ReviewMuse.Data.Models
{
    using ReviewMuse.Data.Models.MappingTables;
    using System.ComponentModel.DataAnnotations;

    using static ReviewMuse.Common.EntityValidationConstraints.Status;

    public class BookStatus
    {
        public BookStatus()
        {
            this.BooksStatuses = new HashSet<UsersBooks>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(StatusMaxLength)]
        public string Status { get; set; } = null!;

        public virtual ICollection<UsersBooks> BooksStatuses { get; set; } = null!;
    }
}
