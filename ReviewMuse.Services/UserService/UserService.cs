namespace ReviewMuse.Services.UserService
{
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using ReviewMuse.Data;
    using ReviewMuse.Data.Models;
    using ReviewMuse.Data.Models.MappingTables;
    using ReviewMuse.Services.Contracts;
    using ReviewMuse.Services.Models.Book;
    using ReviewMuse.Web.Models.ExportModels;
    using ReviewMuse.Web.Models.ExportModels.Enums;

    public class UserService : IUserService
    {
        private readonly ReviewMuseDbContext dbContext;

        public UserService(ReviewMuseDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddToCollectionAsync(ExpoSingleBookViewModel model, string userId)
        {

            int bookStatus = (int)model.BookStatus;

            UsersBooks userBook = new UsersBooks()
            {
                ApplicationUserId = Guid.Parse(userId),
                BookId = Guid.Parse(model.BookId!),
                BookStatusId = bookStatus
            };

            await this.dbContext.UsersBooks.AddAsync(userBook);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<MyCollectionBookEngineModel> MyCollectionAsync(ExpoMyBooksCollectionQueryModel queryModel, string userId)
        {
            IQueryable<Book> booksQuery = this.dbContext
                .Books
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.Category))
            {
                booksQuery = booksQuery
                    .Where(b => b.IsActive &&
                    b.BookCategories.Any(c => c.Category.CategoryName == queryModel.Category)
                    && b.BookUsers.Any(bu => bu.ApplicationUserId.ToString() == userId));
            }

            if (!string.IsNullOrWhiteSpace(queryModel.SearchQuery))
            {
                string wildCard = $"{queryModel.SearchQuery.ToLower()}";

                booksQuery = booksQuery
                    .Where(b => b.IsActive &&
                                b.BookUsers.Any(bu => bu.ApplicationUserId.ToString() == userId) &&
                                b.Title.ToLower().Contains(wildCard) ||
                                b.ISBN.Contains(wildCard) ||
                                b.BookAuthors.Select(a => a.Author.FullName).First().Contains(wildCard));
            }

            booksQuery = queryModel.BookSorting switch
            {
                BookSorting.Recent => booksQuery
                .Where(b => b.IsActive
                && b.BookUsers.Any(bu => bu.ApplicationUserId.ToString() == userId))
                .OrderByDescending(b => b.PublishingDate),
                BookSorting.Oldest => booksQuery
                .Where(b => b.IsActive
                && b.BookUsers.Any(bu => bu.ApplicationUserId.ToString() == userId))
                .OrderBy(b => b.PublishingDate),
                BookSorting.Title => booksQuery
                .Where(b => b.IsActive 
                && b.BookUsers.Any(bu => bu.ApplicationUserId.ToString() == userId))
                .OrderBy(b => b.Title),
                BookSorting.Author => booksQuery
                .Where(b => b.IsActive 
                && b.BookUsers.Any(bu => bu.ApplicationUserId.ToString() == userId))
                .OrderBy(b => b.BookAuthors.Select(a => a.Author.FullName).First()),
                BookSorting.RatingDescending => booksQuery
                .Where(b => b.IsActive 
                && b.BookUsers.Any(bu => bu.ApplicationUserId.ToString() == userId))
                .OrderByDescending(b => b.TotalRating),
                BookSorting.RatingAscending => booksQuery
                .Where(b => b.IsActive 
                && b.BookUsers.Any(bu => bu.ApplicationUserId.ToString() == userId))
                .OrderBy(b => b.TotalRating),
            };

            IEnumerable<ExpoMyBooksCollectionView> allBooks = await booksQuery
                .Skip((queryModel.CurrentPage - 1) * queryModel.BooksPerPage)
                .Take(queryModel.BooksPerPage)
                .Select(b => new ExpoMyBooksCollectionView()
                {
                    BookId = b.Id.ToString(),
                    Title = b.Title,
                    ImageUrl = b.ImageUrl,
                    AuthorsNames = b.BookAuthors
                    .Select(a => new GetAuthorView()
                    {
                        Id = a.AuthorId.ToString(),
                        Name = a.Author.Pseudonim
                    })
                    .ToArray()!                
                })
                .ToArrayAsync();

            int totalbooks = booksQuery.Count();

            return new MyCollectionBookEngineModel()
            {
                TotalBooksCount = totalbooks,
                Books = allBooks
            };
        }
    }
}
