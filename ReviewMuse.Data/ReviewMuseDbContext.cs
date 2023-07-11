namespace ReviewMuse.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    using ReviewMuse.Data.Models;

    public class ReviewMuseDbContext : IdentityDbContext
    {
        public ReviewMuseDbContext(DbContextOptions<ReviewMuseDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<BookCover> BookCovers { get; set; } = null!;
    }
}
