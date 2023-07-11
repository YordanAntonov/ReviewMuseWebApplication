namespace ReviewMuse.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    using ReviewMuse.Data.Models;
    using ReviewMuse.Data.Models.MappingTables;
    using Microsoft.AspNetCore.Identity;

    public class ReviewMuseDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ReviewMuseDbContext(DbContextOptions<ReviewMuseDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Book> Books { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<BookCover> BookCovers { get; set; } = null!;

        public DbSet<Language> Languages { get; set; } = null!;

        public DbSet<BookStatus> BooksStatus { get; set; } = null!;

        public DbSet<UsersBooks> UsersBooks { get; set; } = null!;

        public DbSet<CategoriesBooks> CategoriesBooks { get; set; } = null!;


    }
}
