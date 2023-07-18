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
                    PublishedDate = b.PublishingDate.ToString("dd MMM yyyy")
                })
                .ToArrayAsync();

            int totalbooks = booksQuery.Count();

            return new AllBooksSearchEngineModel()
            {
                TotalBooksCount = totalbooks,
                Books = allBooks
            };
        }
    }
}
