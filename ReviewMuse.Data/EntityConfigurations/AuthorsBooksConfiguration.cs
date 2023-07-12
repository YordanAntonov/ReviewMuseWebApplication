namespace ReviewMuse.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using ReviewMuse.Data.Models.MappingTables;

    public class AuthorsBooksConfiguration : IEntityTypeConfiguration<AuthorsBooks>
    {
        public void Configure(EntityTypeBuilder<AuthorsBooks> builder)
        {
            builder
                .HasKey(e => new { e.AuthorId, e.BookId });

            builder
                .HasOne(a => a.Author)
                .WithMany(a => a.AuthorBooks)
                .HasForeignKey(a => a.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(b => b.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(b => b.BookId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
