namespace ReviewMuse.Services.AuthorService
{
    using Microsoft.EntityFrameworkCore;

    using ReviewMuse.Data;
    using ReviewMuse.Services.Contracts;
    using ReviewMuse.Web.Models.ExportModels;


    public class AuthorService : IAuthorService
    {
        private readonly ReviewMuseDbContext dbContext;
        public AuthorService(ReviewMuseDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> AuthorExistByIdAsync(string id)
        {
            return await this.dbContext
                .Authors
                .AnyAsync(a => a.Id.ToString() == id && a.IsActive);
        }

        public async Task<ExpoAuthorPageViewModel> GetAuthorByIdAsync(string id)
        {
            ExpoAuthorPageViewModel model = await this.dbContext
                .Authors
                .Where(a => a.IsActive && a.Id.ToString() == id)
                .Select(a => new ExpoAuthorPageViewModel()
                {
                    FullName = a.FullName,
                    Pseudonim = a.Pseudonim,
                    Description = a.Description,
                    DateOfBirth = a.DateOfBirth.ToString("dd MMMM yyyy"),
                    DateOfDeath = a.DateOfDeath.HasValue ? a.DateOfDeath.Value.ToString("dd MMMM yyyy") : "Alive",
                    Website = a.Website,
                    ImageUrl = a.ImageUrl,
                    City = a.City,
                    Country = a.Country,
                    Categories = a.AuthorCategories
                    .Select(c => new ExpoCategoryViewModel()
                    {
                        Id = c.CategoryId,
                        CategoryName = c.Category.CategoryName,
                        Description = c.Category.Description,
                    })
                    .ToList(),
                    Books = a.AuthorBooks
                    .Where(b => b.IsActive)
                    .Select(b => new ExpoPartialBookViewModel()
                    {
                        Id = b.BookId.ToString(),
                        Title = b.Book.Title,
                        ImageUrl = b.Book.ImageUrl,
                    })
                    .ToList()
                })
                .FirstAsync();

            return model;
        }
    }
}
