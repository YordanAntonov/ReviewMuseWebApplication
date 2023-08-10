namespace ReviewMuse.Services.Tests
{
    using Microsoft.EntityFrameworkCore;
    using ReviewMuse.Data;
    using ReviewMuse.Services.AuthorService;
    using ReviewMuse.Services.Contracts;
    using static DatabaseSeeder;

    public class AuthorServiceTests
    {
        private DbContextOptions<ReviewMuseDbContext> dbOptions;
        private ReviewMuseDbContext dbContext;

        private IAuthorService authorService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<ReviewMuseDbContext>()
                .UseInMemoryDatabase("ReviewMuseInMemory" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new ReviewMuseDbContext(this.dbOptions);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.authorService = new AuthorService(this.dbContext);
        }

        [Test]
        public async Task AuthorExistByIdShouldReturnTrue()
        {
            string authorId = Author1.Id.ToString();

            bool authorExist = await this.authorService.AuthorExistByIdAsync(authorId);

            Assert.IsTrue(authorExist);
        }

        [Test]
        public async Task AuthorExistByIdShouldReturnFalse()
        {
            string authorId = "e820f610-5983-47e8-b678-946ad817bfb7";

            bool authorDoesNotExist = await this.authorService.AuthorExistByIdAsync(authorId);

            Assert.IsFalse(authorDoesNotExist);
        }

        [Test]
        public async Task GetAuthorViaIdShouldReturnCorrect()
        {
            string authorId = Author1.Id.ToString();

            var author = await this.authorService.GetAuthorByIdAsync(authorId);

            string expectedAuthorName = "Tom Holland";

            Assert.That(expectedAuthorName, Is.EqualTo(author.FullName));
        }

        [Test]
        public async Task GetAuthorForAddingBooksShouldReturnCorrect()
        {
            string expectedAuthorId = Author1.Id.ToString();

            var authors = await this.authorService.GetAuthorForAddingBookAsync();

            foreach (var author in authors)
            {
                Assert.That(expectedAuthorId, Is.EqualTo(author.AuthorId));
            }
        }
    }
}
