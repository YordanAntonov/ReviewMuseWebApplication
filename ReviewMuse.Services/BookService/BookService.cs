using Microsoft.EntityFrameworkCore;
using ReviewMuse.Data;
using ReviewMuse.Services.Contracts;
using ReviewMuse.Web.Models.ExportModels;

namespace ReviewMuse.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly ReviewMuseDbContext dbContext;
        public BookService(ReviewMuseDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<ExpoAllBooksViewModel>> GetAllBooksAsync()
        {
            return await this.dbContext
                .Books
                .Select(b => new ExpoAllBooksViewModel()
                {
                    BookId = b.Id.ToString(),
                    Title = b.Title,
                    AuthorsNames = b.BookAuthors
                    .Select(a => a.Author.Pseudonim)
                    .ToArray()!,
                    ImageUrl = b.ImageUrl,
                    BookRating = b.TotalRating,
                    PublishedDate = b.PublishingDate.ToString("yyyy-MM-dd")
                })
                .ToListAsync();
        }
    }
}
