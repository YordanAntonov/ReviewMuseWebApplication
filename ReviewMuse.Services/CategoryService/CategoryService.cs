namespace ReviewMuse.Services.CategoryService
{
    using Microsoft.EntityFrameworkCore;
    using ReviewMuse.Data;

    using ReviewMuse.Services.Contracts;
    using ReviewMuse.Web.Models.ExportModels;

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

        public async Task<bool> CategoryExistByIdAsync(int id)
        {
            return await this.dbContext
                .Categories
                .AnyAsync(c => c.Id == id);
        }

        public async Task<ExpoCategoryViewModel> GetCategoryByIdAsync(int id)
        {
            return await this.dbContext
                .Categories
                .Select(c => new ExpoCategoryViewModel()
                {
                    Id = c.Id,
                    CategoryName = c.CategoryName,
                    Description = c.Description,
                    Books = c.BooksCategories
                    .Select(b => new ExpoPartialBookViewModel()
                    {
                        Id = b.BookId.ToString(),
                        Title = b.Book.Title,
                        AuthorNames = b.Book.BookAuthors
                        .Select(a => a.Author.Pseudonim)
                        .ToArray(),
                        ImageUrl = b.Book.ImageUrl
                    })
                    .ToArray()
                })
                .FirstOrDefaultAsync(c => c.Id == id);
        }

    }

}
