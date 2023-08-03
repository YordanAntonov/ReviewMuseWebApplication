namespace ReviewMuse.Services.AuthorService
{
    using Microsoft.EntityFrameworkCore;

    using ReviewMuse.Data;
    using ReviewMuse.Data.Models;
    using ReviewMuse.Data.Models.MappingTables;
    using ReviewMuse.Services.Contracts;
    using ReviewMuse.Web.Models.ExportModels;
    using ReviewMuse.Web.Models.ImportModels;

    public class AuthorService : IAuthorService
    {
        private readonly ReviewMuseDbContext dbContext;
        public AuthorService(ReviewMuseDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAuthorAsync(ImpoNewAuthorViewModel model)
        {
            Author author = new Author()
            {
                FullName = model.FullName,
                Description = model.Description,
                DateOfBirth = DateTime.Parse(model.DateOfBirth),
                DateOfDeath = model.DateOfDeath != null ? DateTime.Parse(model.DateOfDeath) : null,
                Pseudonim = model.Pseudonim != null ? model.Pseudonim : null,
                Website = model.Website != null ? model.Website : null,
                ImageUrl = model.ImageUrl != null ? model.ImageUrl : null,
                City = model.CityName,
                Country = model.CountryName
            };

            CategoriesAuthors categoriesAuthors;

            foreach (var category in model.GanresId)
            {
                categoriesAuthors = new CategoriesAuthors()
                {
                    CategoryId = category,
                    AuthorId = author.Id,
                };

                await this.dbContext.CategoriesAuthors.AddAsync(categoriesAuthors);
            }

            await this.dbContext.Authors.AddAsync(author);
            await this.dbContext.SaveChangesAsync();
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
                    Id = a.Id.ToString(),
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

        public async Task<IEnumerable<ExpoAuthorForAddingNewBookView>> GetAuthorForAddingBookAsync()
        {
            IEnumerable<ExpoAuthorForAddingNewBookView> model = await this.dbContext
                .Authors
                .Where(a => a.IsActive)
                .Select(a => new ExpoAuthorForAddingNewBookView()
                {
                    AuthorId = a.Id.ToString(),
                    AuthorName = a.FullName,
                    ImageUrl = a.ImageUrl!
                })
                .OrderBy(a => a.AuthorName)
                .ToListAsync();

            return model;
        }
    }
}
