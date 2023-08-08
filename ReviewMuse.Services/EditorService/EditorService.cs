namespace ReviewMuse.Services.EditorService
{
    using Microsoft.EntityFrameworkCore;

    using ReviewMuse.Data;
    using ReviewMuse.Data.Models;
    using ReviewMuse.Data.Models.MappingTables;
    using ReviewMuse.Services.Contracts;
    using ReviewMuse.Web.Models.ExportModels;
    using ReviewMuse.Web.Models.ImportModels;

    public class EditorService : IEditorService
    {
        private readonly ReviewMuseDbContext dbContext;
        public EditorService(ReviewMuseDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddNewCoverType(ImpoCoverTypeViewModel model)
        {
            BookCover bookCover = new BookCover()
            {
                CoverType = model.CoverName
            };

            await this.dbContext.BookCovers.AddAsync(bookCover);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task AddNewLanguage(ImpoLanguageViewModel model)
        {
            Language language = new Language()
            {
                LanguageName = model.LanguageName
            };

            await this.dbContext.Languages.AddAsync(language);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task BecomeEditorAsync(ImpoNewEditorViewModel model)
        {
            Editor editor = new Editor()
            {
                UserId = Guid.Parse(model.UserId!),
                PhoneNumber = model.PhoneNumber,
                DateOfBirth = DateTime.Parse(model.DateOfBirth)
            };

            await this.dbContext.Editors.AddAsync(editor);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task EditAuthorAsync(ImpoNewAuthorViewModel model)
        {
            Author author = await this.dbContext
               .Authors
               .FirstAsync(a => a.IsActive && a.Id.ToString() == model.AuthorId);

            author.FullName = model.FullName;
            author.Description = model.Description;
            author.DateOfBirth = DateTime.Parse(model.DateOfBirth);
            author.DateOfDeath = model.DateOfDeath == null ? null : DateTime.Parse(model.DateOfDeath);
            author.Website = model.Website == null ? null : model.Website;
            author.ImageUrl = model.ImageUrl == null ? null : model.ImageUrl;
            author.City = model.CityName;
            author.Country = model.CountryName;
            author.Pseudonim = model.Pseudonim == null ? null : model.Pseudonim;

            if (model.GanresId != null)
            {
                foreach (var ganre in model.GanresId)
                {
                    CategoriesAuthors categoriesAuthors = new CategoriesAuthors()
                    {
                        CategoryId = ganre,
                        Author = author
                    };

                    await this.dbContext.CategoriesAuthors.AddAsync(categoriesAuthors);
                }
            }

            await this.dbContext.SaveChangesAsync();
        }

        public async Task EditBookAsync(ImpoNewBookViewModel model)
        {
            Book book = await this.dbContext
                .Books
                .FirstAsync(b => b.IsActive && b.Id.ToString() == model.BookId);

            book.Title = model.Title;
            book.Description = model.Description;
            book.NumberOfPages = model.NumberOfPages;
            book.ISBN = model.ISBN;
            book.LanguageId = model.LanguageId;
            book.BookCoverId = model.CoverId;
            book.AmazonUrl = model.AmazonLink;
            book.ImageUrl = model.ImageUrl;
            book.PublishingDate = DateTime.Parse(model.PublishingDate);

            if (model.GanresId != null)
            {
                foreach (var ganre in model.GanresId)
                {
                    CategoriesBooks categotyBooks = new CategoriesBooks()
                    {
                        CategoryId = ganre,
                        Book = book
                    };

                    await this.dbContext.CategoriesBooks.AddAsync(categotyBooks);
                }
            }

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<ImpoNewAuthorViewModel> GetEditAuthorAsync(string authorId)
        {
            Author author = await this.dbContext
               .Authors
               .FirstAsync(a => a.Id.ToString() == authorId && a.IsActive);

            ImpoNewAuthorViewModel model = new ImpoNewAuthorViewModel()
            {
                AuthorId = author.Id.ToString(),
                FullName = author.FullName,
                Description = author.Description,
                DateOfBirth = author.DateOfBirth.ToString("yyyy-MM-dd"),
                DateOfDeath = author.DateOfDeath.HasValue ? author.DateOfDeath.Value.ToString("yyyy-MM-dd") : null,
                Website = author.Website,
                ImageUrl = author.ImageUrl,
                CityName = author.City,
                CountryName = author.Country,
                Pseudonim = author.Pseudonim
            };

            return model;
        }

        public async Task<ImpoNewBookViewModel> GetEditBookAsync(string bookId)
        {
            Book book = await this.dbContext
                .Books
                .FirstAsync(b => b.Id.ToString() == bookId && b.IsActive);

            ImpoNewBookViewModel model = new ImpoNewBookViewModel()
            {
                BookId = bookId,
                Title = book.Title,
                Description = book.Description,
                PublishingDate = book.PublishingDate.ToString("yyyy-MM-dd"),
                ImageUrl = book.ImageUrl,
                NumberOfPages = book.NumberOfPages,
                ISBN = book.ISBN,
                AmazonLink = book.AmazonUrl
            };

            return model;
        }

        public async Task<IEnumerable<ExpoPartialBookViewModel>> GetEditorBooksAsync(string editorId)
        {
            IEnumerable<ExpoPartialBookViewModel> model = await this.dbContext
                .Books
                .Where(b => b.EditorId.ToString() == editorId && b.IsActive)
                .Select(b => new ExpoPartialBookViewModel()
                {
                    Id = b.Id.ToString(),
                    Title = b.Title,
                    ImageUrl = b.ImageUrl,
                    AuthorNames = b.BookAuthors.Select(a => a.Author.FullName)
                    .ToArray(),
                })
                .OrderBy(b => b.Title)
                .ToArrayAsync();
                
            return model;
        }

        public async Task<string> GetEditorIdViaUserIdAsync(Guid userId)
        {
            var editorId = await this.dbContext
                .Editors
                .FirstAsync(e => e.UserId == userId);

            return editorId.Id.ToString();
        }

        public async Task<bool> IsUserEditorById(Guid id)
        {
            return await this.dbContext
                .Editors
                .AnyAsync(e => e.UserId == id && e.IsActive);
        }

        public async Task<bool> IsUserEditorByIdNonActive(Guid id)
        {
            return await this.dbContext
               .Editors
               .AnyAsync(e => e.UserId == id);
        }

        public async Task RemoveBookAsync(string id)
        {
            Book book = await this.dbContext
                .Books
                .FirstAsync(b => b.IsActive && b.Id.ToString() == id);

            book.IsActive = false;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task RemoveEditor(string id)
        {
            Editor editor = await this.dbContext
                .Editors
                .FirstAsync(e => e.UserId.ToString() == id);

            editor.IsActive = false;

            await this.dbContext.SaveChangesAsync();
        }
    }
}
