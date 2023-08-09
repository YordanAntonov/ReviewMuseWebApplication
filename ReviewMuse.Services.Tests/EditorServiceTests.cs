namespace ReviewMuse.Services.Tests
{
    using Microsoft.EntityFrameworkCore;
    using ReviewMuse.Data;
    using ReviewMuse.Services.Contracts;
    using ReviewMuse.Services.EditorService;
    using ReviewMuse.Web.Models.ExportModels;
    using ReviewMuse.Web.Models.ImportModels;

    using static DatabaseSeeder;

    public class EditorServiceTests
    {
        private DbContextOptions<ReviewMuseDbContext> dbOptions;
        private ReviewMuseDbContext dbContext;

        private IEditorService editorService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<ReviewMuseDbContext>()
                .UseInMemoryDatabase("ReviewMuseInMemory" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new ReviewMuseDbContext(this.dbOptions);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.editorService = new EditorService(this.dbContext);
        }

        [Test]
        public async Task IsUserEditorByIdShouldReturnTrue()
        {
            string editorId = UserEditor.Id.ToString();

            bool result = await this.editorService.IsUserEditorById(Guid.Parse(editorId));


            Assert.IsTrue(result);
        }

        [Test]
        public async Task IsUserEditorByIdShouldReturnFalse()
        {
            string normalUserId = NormalUser.Id.ToString();

            bool result = await this.editorService.IsUserEditorById(Guid.Parse(normalUserId));

            Assert.IsFalse(result);
        }

        [Test]
        public async Task IsUserEditorByIdNonActiveShouldBeTrue()
        {
            string nonActiveEditorId = NonActiveEditor.Id.ToString();

            bool result = await this.editorService.IsUserEditorByIdNonActive(Guid.Parse(nonActiveEditorId));

            Assert.IsTrue(result);
        }

        [Test]
        public async Task IsUserEditorByIdNonActiveShouldBeFalse()
        {
            string activeEditor = UserEditor.Id.ToString();

            bool result = await this.editorService.IsUserEditorByIdNonActive(Guid.Parse(activeEditor));

            Assert.IsTrue(result);
        }

        [Test]
        public async Task GetEditorIdViaUserIdShouldBeCorrect()
        {
            string userId = UserEditor.Id.ToString();

            string editorId = await this.editorService.GetEditorIdViaUserIdAsync(Guid.Parse(userId));

            string realEditorId = Editor.Id.ToString();

            Assert.That(editorId, Is.EqualTo(realEditorId));
        }

        [Test]
        public async Task RemoveEditorAsyncShouldMakeTheEditorNonActive()
        {
            string editorToRemoveId = UserEditor.Id.ToString();

            await this.editorService.RemoveEditor(editorToRemoveId);

            bool expectedEditorIsActive = Editor.IsActive;

            Assert.IsFalse(expectedEditorIsActive);
        }

        [Test]
        public async Task RemoveBookAsyncShouldMakeBookNotActive()
        {
            string bookId = Book1.Id.ToString();

            await this.editorService.RemoveBookAsync(bookId);

            bool expectedResult = Book1.IsActive;

            Assert.IsFalse(expectedResult);
        }

        [Test]
        public async Task GetEditorsBookShouldReturnCorrectCount()
        {
            string editorId = Editor.Id.ToString();

            IEnumerable<ExpoPartialBookViewModel> books = await this.editorService.GetEditorBooksAsync(editorId);

            int expectedCount = 1;

            int actualCount = books.Count();

            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }

        [Test]
        public async Task GetEditBookShouldReturnCorrectAmountOfBooks()
        {
            string bookId = Book1.Id.ToString();

            ImpoNewBookViewModel book = await this.editorService.GetEditBookAsync(bookId);

            string expectedBookTitle = "Oppenhaimer";

            Assert.That(book.Title, Is.EqualTo(expectedBookTitle));
        }

        [Test]
        public async Task GetAuthorAsyncShouldReturnTheCorrectAuthor()
        {
            string authorId = Author1.Id.ToString();

            ImpoNewAuthorViewModel author = await this.editorService.GetEditAuthorAsync(authorId);

            string expectedAuthorName = "Tom Holland";

            Assert.That(author.FullName, Is.EqualTo(expectedAuthorName));
        }
    }
}