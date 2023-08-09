namespace ReviewMuse.Services.Tests
{
    using Microsoft.EntityFrameworkCore;
    using ReviewMuse.Data;
    using ReviewMuse.Services.BookService;
    using ReviewMuse.Services.Contracts;
    using ReviewMuse.Web.Models.ExportModels;
    using System;
    using static DatabaseSeeder;

    public class BookServiceTests
    {
        private DbContextOptions<ReviewMuseDbContext> dbOptions;
        private ReviewMuseDbContext dbContext;

        private IBookService bookService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<ReviewMuseDbContext>()
                .UseInMemoryDatabase("ReviewMuseInMemory" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new ReviewMuseDbContext(this.dbOptions);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.bookService = new BookService(this.dbContext);
        }

        [Test]
        public async Task AddRatingToBookAsyncShouldPutRatingCorrectly()
        {
            string bookId = Book1.Id.ToString();

            int rating = 5;

            await this.bookService.AddRatingToBookAsync(rating, bookId);

            Assert.That(Book1.TotalRating, Is.EqualTo(rating));
        }

        [Test]
        public async Task BookExistByIdShouldBeTrue()
        {
            string bookId = Book1.Id.ToString();

            bool bookExist = await this.bookService.BookExistsById(bookId);

            Assert.IsTrue(bookExist);
        }

        [Test]
        public async Task BookExistByIdShouldBeFalse()
        {
            string randomNonExistantBookId = "ed414ab5-a4aa-45cf-a916-4d97b8612787";

            bool bookExist = await this.bookService.BookExistsById(randomNonExistantBookId);

            Assert.IsFalse(bookExist);
        }

        [Test]
        public async Task GetBookByIdShouldReturnTheCorrectBook()
        {
            string bookId = Book1.Id.ToString();

            ExpoSingleBookViewModel book = await this.bookService.GetBookByIdAsync(bookId);

            string expectedName = "Oppenhaimer";

            Assert.That(book.Title, Is.EqualTo(expectedName));
        }

        [Test]
        public async Task GetBookEditorIdShouldReturnCorrectEditorId()
        {
            string bookId = Book1.Id.ToString();

            string expectedId = Book1.EditorId.ToString();

            string editorId = await this.bookService.GetBookEditorId(bookId);

            Assert.That(editorId, Is.EqualTo(expectedId));
        }
    }
}
