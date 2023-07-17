namespace ReviewMuse.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using ReviewMuse.Data.Models;

    public class BookCoversConfiguration : IEntityTypeConfiguration<BookCover>
    {
        public void Configure(EntityTypeBuilder<BookCover> builder)
        {
            //builder.HasData(this.GenerateBookCovers());
        }

        private BookCover[] GenerateBookCovers()
        {
            ICollection<BookCover> booksCovers = new HashSet<BookCover>();

            BookCover bookCover;

            bookCover = new BookCover()
            {
                Id = 1,
                CoverType = "E-book"
            };
            booksCovers.Add(bookCover);

            bookCover = new BookCover()
            {
                Id = 2,
                CoverType = "Paperback"
            };
            booksCovers.Add(bookCover);

            bookCover = new BookCover()
            {
                Id = 3,
                CoverType = "Hardcover"
            };
            booksCovers.Add(bookCover);

            bookCover = new BookCover()
            {
                Id = 4,
                CoverType = "Audiobook"
            };
            booksCovers.Add(bookCover);

            return booksCovers.ToArray();
        }
    }
}
