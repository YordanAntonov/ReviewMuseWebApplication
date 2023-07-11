namespace ReviewMuse.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static ReviewMuse.Common.EntityValidationConstraints.Status;

    public class BookStatus
    {
        public BookStatus()
        {
            this.BooksStatuses = new HashSet<Book>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(StatusMaxLength)]
        public string Status { get; set; } = null!;

        public virtual ICollection<Book> BooksStatuses { get; set; } = null!;
    }
}
