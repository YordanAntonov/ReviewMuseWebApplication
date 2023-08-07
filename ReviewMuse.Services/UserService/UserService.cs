namespace ReviewMuse.Services.UserService
{
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using ReviewMuse.Data;
    using ReviewMuse.Data.Models;
    using ReviewMuse.Data.Models.MappingTables;
    using ReviewMuse.Services.Contracts;
    using ReviewMuse.Services.Models.Book;
    using ReviewMuse.Web.Models.Enums;
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

        public async Task<Web.Models.Enums.BookStatus> GetUserBookStatus(string userId, string bookId)
        {
            var status = await this.dbContext
                .UsersBooks
                .FirstAsync(b => b.IsActive && b.ApplicationUserId.ToString() == userId && b.BookId.ToString() == bookId);

            return (Web.Models.Enums.BookStatus)status.BookStatusId;
        }

        public async Task<ExpoUserInfoViewModel> GetUserInfoAsync(string userId)
        {
            ApplicationUser user = await this.dbContext
                .Users
                .FirstAsync(u => u.Id.ToString() == userId);


            ExpoUserInfoViewModel model = new ExpoUserInfoViewModel()
            {
                UserName = user.UserName,
                Email = user.Email,
                TotalStars = await this.GetUserTotalStars(userId),
                CountOfBookReviews = await this.GetUserTotalReviews(userId),
            };

            return model;
                
        }

        public async Task<int> GetUserTotalReviews(string userId)
        {
            var totalReviews = await this.dbContext
                .Reviews
                .Where(r => r.UserId.ToString() == userId)
                .ToListAsync();

            int count = totalReviews.Count();

            return count;
        }

        public async Task<int> GetUserTotalStars(string userId)
        {
            var reviews = await this.dbContext
                .Reviews
                .Where(r => r.UserId.ToString() == userId)
                .ToListAsync();

            int count = 0;

            foreach (var review in reviews)
            {
                count += review.Rating;
            }

            return count;
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

        public async Task RemoveFromFavouritesAsync(string bookId, string userId)
        {
            UsersBooks userBook = await this.dbContext
                .UsersBooks
                .FirstAsync(b => b.BookId.ToString() == bookId && b.ApplicationUserId.ToString() == userId);


            this.dbContext.Remove(userBook);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task RemoveUserAsync(string userId, bool isUserEditor)
        {
            ApplicationUser user = await this.dbContext
                .Users.FirstAsync(u => u.Id.ToString() == userId);

            if (isUserEditor)
            {
                Editor editor = await this.dbContext
                    .Editors
                    .FirstAsync(u => u.UserId.ToString() == userId);

                this.dbContext.Editors.Remove(editor);
            }

            this.dbContext.Users.Remove(user);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task UpdateToCollectionBookAsync(ExpoSingleBookViewModel model, string userId)
        {
            int bookStatus = (int)model.BookStatus;

            var userBook = await this.dbContext
                .UsersBooks
                .FirstAsync(u => u.IsActive && u.BookId.ToString() == model.BookId && u.ApplicationUserId.ToString() == userId);

            userBook.BookStatusId = bookStatus;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<bool> UserHasBookAsFavouriteAsync(string bookId, string userId)
        {
            return await this.dbContext
                .UsersBooks.AnyAsync(b => b.IsActive && b.BookId.ToString() == bookId && b.ApplicationUserId.ToString() == userId);
        }
    }
}
