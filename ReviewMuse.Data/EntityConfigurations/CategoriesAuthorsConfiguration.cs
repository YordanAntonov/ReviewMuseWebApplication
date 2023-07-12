namespace ReviewMuse.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using ReviewMuse.Data.Models.MappingTables;

    public class CategoriesAuthorsConfiguration : IEntityTypeConfiguration<CategoriesAuthors>
    {
        public void Configure(EntityTypeBuilder<CategoriesAuthors> builder)
        {
            builder
                .HasKey(entity => new { entity.CategoryId, entity.AuthorId });

            builder
                .HasOne(a => a.Author)
                .WithMany(a => a.AuthorCategories)
                .HasForeignKey(a => a.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.Category)
                .WithMany(c => c.AuthorsCategory)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
