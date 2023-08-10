namespace ReviewMuse.Services.Tests
{
    using Microsoft.EntityFrameworkCore;
    using ReviewMuse.Data;
    using ReviewMuse.Services.Contracts;
    using ReviewMuse.Services.ReviewService;
    using static DatabaseSeeder;

    public class ReviewServiceTests
    {
        private DbContextOptions<ReviewMuseDbContext> dbOptions;
        private ReviewMuseDbContext dbContext;

        private IReviewService reviewService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<ReviewMuseDbContext>()
                .UseInMemoryDatabase("ReviewMuseInMemory" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new ReviewMuseDbContext(this.dbOptions);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.reviewService = new ReviewService(this.dbContext);
        }

        [Test]
        public async Task GetAllReviewsShouldReturnZero()
        {
            string bookId = Book1.Id.ToString();

            int expectedReviewCount = 0;

            var reviews = await this.reviewService.GetAllReviewsAsync(bookId);

            Assert.That(reviews.Count(), Is.EqualTo(expectedReviewCount));
        }

        [Test]
        public async Task BookHasReviewsShouldReturnFalse()
        {
            string bookId = Book1.Id.ToString();

            bool hasReviews = await this.reviewService.BookHasReviewsAsync(bookId);

            Assert.IsFalse(hasReviews);
        }

        [Test]
        public async Task BookHasReviewsShouldReturnTrue()
        {
            string bookId = "e8d72eb0-e4df-41a4-8e8e-89394018dd54";

            bool hasReviews = await this.reviewService.BookHasReviewsAsync(bookId);

            Assert.IsTrue(hasReviews);
        }

        [Test]
        public async Task RemovingReviewShouldReturnIsActiveFalse()
        {
            string reviewId = Review1.Id.ToString();

            Review1.BookId = Book1.Id;

            await this.reviewService.RemoveReviewAsync(reviewId);

            Assert.IsFalse(Review1.IsActive);
        }

        [Test]
        public async Task WhenRemovingReviewTheStarsOfBookShouldDecrease()
        {
            string reviewId = Review1.Id.ToString();

            Review1.BookId = Book1.Id;
            Book1.TotalRating += 4;

            await this.reviewService.RemoveReviewAsync(reviewId);

            int epxectedStars = -4;

            Assert.That(Book1.TotalRating, Is.EqualTo(epxectedStars));
        }

        [Test]
        public async Task ReviewExistsByIdShouldReturnTrue()
        {
            string reviewId = Review1.Id.ToString();

            bool reviewExist = await this.reviewService.ReviewExistByIdAsync(reviewId);

            Assert.IsTrue(reviewExist);
        }

        [Test]
        public async Task ReviewExistsByIdShouldReturnFalse()
        {
            string reviewId = "2ab7b29b-bdd3-4423-af4f-15820ac7fb95";

            bool reviewExist = await this.reviewService.ReviewExistByIdAsync(reviewId);

            Assert.IsFalse(reviewExist);
        }
    }
}
