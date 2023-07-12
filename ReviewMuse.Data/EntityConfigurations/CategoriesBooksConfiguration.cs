namespace ReviewMuse.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using ReviewMuse.Data.Models.MappingTables;

    public class CategoriesBooksConfiguration : IEntityTypeConfiguration<CategoriesBooks>
    {
        public void Configure(EntityTypeBuilder<CategoriesBooks> builder)
        {
            //Table composite key
            builder
                .HasKey(e => new { e.CategoryId, e.BookId });

            builder
                .HasOne(b => b.Book)
                .WithMany(b => b.BookCategories)
                .HasForeignKey(b => b.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.Category)
                .WithMany(c => c.BooksCategories)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}
