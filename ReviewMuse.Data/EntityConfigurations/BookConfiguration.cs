namespace ReviewMuse.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using ReviewMuse.Data.Models;

    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder
                .HasOne(e => e.Editor)
                .WithMany(e => e.EditorBooks)
                .HasForeignKey(e => e.EditorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(bc => bc.BookCover)
                .WithMany(bc => bc.BookCovers)
                .HasForeignKey(bc => bc.BookCoverId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(l => l.Language)
                .WithMany(l => l.BooksLanguages)
                .HasForeignKey(l => l.LanguageId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
