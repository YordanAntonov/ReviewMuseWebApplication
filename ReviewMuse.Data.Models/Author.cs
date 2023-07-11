namespace ReviewMuse.Data.Models
{
    using ReviewMuse.Data.Models.MappingTables;
    using System.ComponentModel.DataAnnotations;

    using static ReviewMuse.Common.EntityValidationConstraints.Author;
    public class Author
    {
        public Author()
        {
            this.AuthorBooks = new HashSet<AuthorsBooks>();
            this.AuthorCategories = new HashSet<CategoriesAuthors>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string FullName { get; set; } = null!;

        [Required]
        [MaxLength]
        public string Description { get; set; } = null!;

        public DateTime DateOfBirth { get; set; }

        public DateTime? DateOfDeath { get; set; }

        public string? Website { get; set; }

        public string? ImageUrl { get; set; }

        [Required]
        [MaxLength(CityNameMaxLength)]
        public string City { get; set; } = null!;

        [Required]
        [MaxLength(CountryNameMaxLength)]
        public string Country { get; set; } = null!;

        public bool IsActive { get; set; }

        public virtual ICollection<AuthorsBooks> AuthorBooks { get; set; } = null!;

        public virtual ICollection<CategoriesAuthors> AuthorCategories { get; set; } = null!;
    }
}
