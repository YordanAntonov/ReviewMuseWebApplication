
namespace ReviewMuse.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static ReviewMuse.Common.EntityValidationConstraints.Editor;

    public class Editor
    {
        public Editor()
        {
            this.EditorSince = DateTime.UtcNow;
            this.EditorBooks = new HashSet<Book>();
            this.IsActive = true;
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(PhoneMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        public virtual ApplicationUser User { get; set; } = null!;

        public DateTime DateOfBirth { get; set; }

        public DateTime EditorSince { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Book> EditorBooks { get; set; } = null!;
    }
}
