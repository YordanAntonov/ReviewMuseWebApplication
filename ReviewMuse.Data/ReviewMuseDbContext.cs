namespace ReviewMuse.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    public class ReviewMuseDbContext : IdentityDbContext
    {
        public ReviewMuseDbContext(DbContextOptions<ReviewMuseDbContext> options)
            : base(options)
        {
            
        }


    }
}
