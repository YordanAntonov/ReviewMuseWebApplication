namespace ReviewMuse.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static ReviewMuse.Common.EntityValidationConstraints.BookCoverType;

    public class BookCover
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TypeNameMaxLength)]
        public string CoverType { get; set; } = null!;
    }
}
