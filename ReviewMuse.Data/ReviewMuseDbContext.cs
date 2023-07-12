namespace ReviewMuse.Data
{
    using System.Reflection;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    using ReviewMuse.Data.Models;
    using ReviewMuse.Data.Models.MappingTables;

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

        public DbSet<CategoriesAuthors> CategoriesAuthors { get; set; } = null!;

        public DbSet<CategoriesBooks> CategoriesBooks { get; set; } = null!;

        public DbSet<AuthorsBooks> AuthorsBooks { get; set; } = null!;

        public DbSet<Editor> Editors { get; set; } = null!;

        public DbSet<Author> Authors { get; set; } = null!;

        public DbSet<Review> Reviews { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssembly = Assembly.GetAssembly(typeof(ReviewMuseDbContext)) ??
                                      Assembly.GetExecutingAssembly();

            builder.ApplyConfigurationsFromAssembly(configAssembly);

            base.OnModelCreating(builder);
        }
    }
}
    