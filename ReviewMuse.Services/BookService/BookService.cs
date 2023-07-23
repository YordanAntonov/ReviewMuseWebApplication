namespace ReviewMuse.Services.BookService
{
    using Microsoft.EntityFrameworkCore;

    using ReviewMuse.Data;
    using ReviewMuse.Data.Models;

    using ReviewMuse.Services.Contracts;
    using ReviewMuse.Services.Models.Book;

    using ReviewMuse.Web.Models.ExportModels;
    using ReviewMuse.Web.Models.ExportModels.Enums;


    public class BookService : IBookService
    {
        private readonly ReviewMuseDbContext dbContext;
        public BookService(ReviewMuseDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddRatingToBookAsync(int rating, string bookId)
        {
            Book book = await dbContext
                .Books
                .FirstAsync(b => b.Id.ToString() == bookId);

            book.TotalRating += rating;

            await dbContext.SaveChangesAsync();
        }

        public async Task<AllBooksSearchEngineModel> AllAsync(ExpoAllBooksQueryViewModel queryModel)
        {
            IQueryable<Book> booksQuery = this.dbContext
                .Books
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.Category))
            {
                booksQuery = booksQuery
                    .Where(b => b.IsActive &&
                    b.BookCategories.Any(c => c.Category.CategoryName == queryModel.Category));
            }

            if (!string.IsNullOrWhiteSpace(queryModel.SearchQuery))
            {
                string wildCard = $"{queryModel.SearchQuery.ToLower()}";

                booksQuery = booksQuery
                    .Where(b => b.IsActive &&
                                b.Title.ToLower().Contains(wildCard) ||
                                b.ISBN.Contains(wildCard) ||
                                b.BookAuthors.Select(a => a.Author.FullName).First().Contains(wildCard));
            }

            booksQuery = queryModel.BookSorting switch
            {
                BookSorting.Recent => booksQuery
                .Where(b => b.IsActive)
                .OrderByDescending(b => b.PublishingDate),
                BookSorting.Oldest => booksQuery
                .Where(b => b.IsActive)
                .OrderBy(b => b.PublishingDate),
                BookSorting.Title => booksQuery
                .Where(b => b.IsActive)
                .OrderBy(b => b.Title),
                BookSorting.Author => booksQuery
                .Where(b => b.IsActive)
                .OrderBy(b => b.BookAuthors.Select(a => a.Author.FullName).First()),
                BookSorting.RatingDescending => booksQuery
                .Where(b => b.IsActive)
                .OrderByDescending(b => b.TotalRating),
                BookSorting.RatingAscending => booksQuery
                .Where(b => b.IsActive)
                .OrderBy(b => b.TotalRating),
            };

            IEnumerable<ExpoAllBooksViewModel> allBooks = await booksQuery
                .Skip((queryModel.CurrentPage - 1) * queryModel.BooksPerPage)
                .Take(queryModel.BooksPerPage)
                .Select(b => new ExpoAllBooksViewModel()
                {
                    BookId = b.Id.ToString(),
                    Title = b.Title,
                    ImageUrl = b.ImageUrl,
                    AuthorsNames = b.BookAuthors
                    .Select(a => a.Author.Pseudonim)
                    .ToArray()!,
                    BookRating = b.TotalRating,
                    PublishedDate = b.PublishingDate.ToString("dd MMM, yyyy")
                })
                .ToArrayAsync();

            int totalbooks = booksQuery.Count();

            return new AllBooksSearchEngineModel()
            {
                TotalBooksCount = totalbooks,
                Books = allBooks
            };
        }

        public async Task<bool> BookExistsById(string id)
        {
            return await this.dbContext
                .Books
                .AnyAsync(b => b.Id.ToString() == id && b.IsActive);
        }

        public async Task<ExpoSingleBookViewModel> GetBookByIdAsync(string id)
        {
            ExpoSingleBookViewModel model = await this.dbContext
                .Books
                .Where(b => b.IsActive)
                .Select(b => new ExpoSingleBookViewModel()
                {
                    BookId = b.Id.ToString(),
                    Title = b.Title,
                    Description = b.Description,
                    PagesCount = b.NumberOfPages,
                    ImageUrl = b.ImageUrl!,
                    AuthorsNames = b.BookAuthors
                    .Select(a => new ExpoPartialAuthorViewModel()
                    {
                        AuthorId = a.AuthorId.ToString(),
                        AuthorPseudonim = a.Author.Pseudonim,
                        Description = a.Author.Description,
                        BooksCount = a.Author.AuthorBooks.Count,
                        ImageUrl = a.Author.ImageUrl,
                        BirthDate = a.Author.DateOfBirth.ToString("MMMM dd, yyyy")
                    })
                    .ToList(),
                    PublishingDate = b.PublishingDate.ToString("MMMM dd, yyyy"),
                    ISBN = b.ISBN,
                    Language = b.Language.LanguageName,
                    CoverType = b.BookCover.CoverType,
                    TotalRating = b.TotalRating,
                    CategoriesNames = b.BookCategories
                    .Select(c => new ExpoCategoryViewModel()
                    {
                        Id = c.Category.Id,
                        CategoryName = c.Category.CategoryName,
                        Description = c.Category.Description
                    })
                    .ToList()
                })
                .FirstAsync(b => b.BookId == id);

            return model;
        }


    }
}
