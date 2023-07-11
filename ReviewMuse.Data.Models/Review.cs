namespace ReviewMuse.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Review
    {
        public Review()
        {
            this.PostedOn = DateTime.UtcNow;
        }

        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        [Required]
        public virtual ApplicationUser User { get; set; } = null!;

        [ForeignKey(nameof(Book))]
        public Guid BookId { get; set; }

        [Required]
        public virtual Book Book { get; set; } = null!;

        public int Rating { get; set; }

        [Required]
        [MaxLength]
        public string Comment { get; set; } = null!;

        public DateTime PostedOn { get; set; }
    }
}
