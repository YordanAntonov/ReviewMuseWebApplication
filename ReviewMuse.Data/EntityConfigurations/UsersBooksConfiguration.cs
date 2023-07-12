namespace ReviewMuse.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using ReviewMuse.Data.Models.MappingTables;

    public class UsersBooksConfiguration : IEntityTypeConfiguration<UsersBooks>
    {
        public void Configure(EntityTypeBuilder<UsersBooks> builder)
        {
            builder
                .HasKey(entity => new { entity.BookId, entity.ApplicationUserId });

            builder
                .HasOne(b => b.Book)
                .WithMany(b => b.BookUsers)
                .HasForeignKey(b => b.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(u => u.ApplicationUser)
                .WithMany(u => u.UserBooks)
                .HasForeignKey(u => u.ApplicationUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(s => s.BookStatus)
                .WithMany(s => s.BooksStatuses)
                .HasForeignKey(s => s.BookStatusId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
