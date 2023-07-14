namespace ReviewMuse.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using ReviewMuse.Data.Models;

    public class BookStatusesConfiguration : IEntityTypeConfiguration<BookStatus>
    {
        public void Configure(EntityTypeBuilder<BookStatus> builder)
        {
            builder.HasData(this.GenerateBookStatuses());
        }

        private BookStatus[] GenerateBookStatuses()
        {
            ICollection<BookStatus> booksStatuses = new HashSet<BookStatus>();

            BookStatus bookStatus;

            bookStatus = new BookStatus()
            {
                Id = 1,
                Status = "Reading"
            };
            booksStatuses.Add(bookStatus);

            bookStatus = new BookStatus()
            {
                Id = 2,
                Status = "Read"
            };
            booksStatuses.Add(bookStatus);

            bookStatus = new BookStatus()
            {
                Id = 3,
                Status = "Want to Read"
            };
            booksStatuses.Add(bookStatus);

            return booksStatuses.ToArray();
        }
    }
}
