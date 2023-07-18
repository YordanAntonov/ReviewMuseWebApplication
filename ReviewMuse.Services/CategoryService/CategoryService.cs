namespace ReviewMuse.Services.CategoryService
{
    using Microsoft.EntityFrameworkCore;
    using ReviewMuse.Data;

    using ReviewMuse.Services.Contracts;
    public class CategoryService : ICategoryService
    {
        private readonly ReviewMuseDbContext dbContext;
        public CategoryService(ReviewMuseDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<string>> AllCategoriesAsync()
        {
            return await this.dbContext
                .Categories
                .Select(c => c.CategoryName)
                .OrderBy(c => c)
                .ToListAsync();
        }
    }
}
