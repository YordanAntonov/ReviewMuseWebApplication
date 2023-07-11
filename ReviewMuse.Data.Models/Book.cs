namespace ReviewMuse.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static ReviewMuse.Common.EntityValidationConstraints.Book;
    using ReviewMuse.Data.Models.MappingTables;

    public class Book
    {
        public Book()
        {
            this.RecordCreatedOn = DateTime.UtcNow;

            this.BookCategories = new HashSet<CategoriesBooks>();
            this.BookAuthors = new HashSet<AuthorsBooks>();
            this.BookUsers = new HashSet<UsersBooks>();
            this.Reviews = new HashSet<Review>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength()]
        public string Description { get; set; } = null!;

        public DateTime PublishingDate { get; set; }

        public DateTime RecordCreatedOn { get; set; }

        public bool IsActive { get; set; }

        [MaxLength()]
        public string? ImageUrl { get; set; }

        [Required]
        public int NumberOfPages { get; set; }

        [Required]
        [MaxLength(BookIsbnSize)]
        public string ISBN { get; set; } = null!;

        public int TotalRating { get; set; }

        [ForeignKey(nameof(Editor))]
        public virtual Guid EditorId { get; set; }

        [Required]
        public virtual Editor Editor { get; set; } = null!;


        [ForeignKey(nameof(BookCover))]
        public int BookCoverId { get; set; }

        [Required]
        public virtual BookCover BookCover { get; set; } = null!;


        [ForeignKey(nameof(Language))]
        public int LanguageId { get; set; }

        [Required]
        public virtual Language Language { get; set; } = null!;


        public virtual ICollection<CategoriesBooks> BookCategories { get; set; } = null!;

        public virtual ICollection<UsersBooks> BookUsers { get; set; } = null!;

        public virtual ICollection<Review> Reviews { get; set; } = null!;

        public virtual ICollection<AuthorsBooks> BookAuthors { get; set; } = null!;
    }
}
