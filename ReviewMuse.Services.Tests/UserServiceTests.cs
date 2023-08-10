namespace ReviewMuse.Services.Tests
{
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;
    using ReviewMuse.Data;
    using ReviewMuse.Services.Contracts;
    using ReviewMuse.Services.UserService;
    using static DatabaseSeeder;

    public class UserServiceTests
    {
        private DbContextOptions<ReviewMuseDbContext> dbOptions;
        private ReviewMuseDbContext dbContext;

        private IUserService userService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<ReviewMuseDbContext>()
                .UseInMemoryDatabase("ReviewMuseInMemory" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new ReviewMuseDbContext(this.dbOptions);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.userService = new UserService(this.dbContext);
        }

        [Test]
        public async Task GetAllUsersShouldReturnTwoUsers()
        {
            var users = await this.userService.AllUsersAsync();

            int expectedCount = 3;

            Assert.That(users.Count(), Is.EqualTo(expectedCount));
        }

        [Test]
        public async Task GetUserInfoAsyncShouldReturnCorrect()
        {
            string userId = UserEditor.Id.ToString();

            var userInfo = await this.userService.GetUserInfoAsync(userId);

            string expectedUserId = "ZeroXp";

            Assert.That(userInfo.UserName, Is.EqualTo(expectedUserId));
        }

        [Test]
        public async Task GetUserStarsShouldReturnCorrectAmount()
        {
            string userId = "173db7a0-e1ad-45b5-82be-a871643ea3fb";

            int expectedStars = 4;

            int userStars = await this.userService.GetUserTotalStars(userId);

            Assert.That(userStars, Is.EqualTo(expectedStars));
        }

        [Test]
        public async Task GetUserReviewsCountShouldBeCorrect()
        {
            string userId = "173db7a0-e1ad-45b5-82be-a871643ea3fb";

            int expectedReviewsCount = 1;

            int userReviews = await this.userService.GetUserTotalReviews(userId);

            Assert.That(userReviews, Is.EqualTo(expectedReviewsCount));
        }

        [Test]
        public async Task UserHasBooksInFavouritesShouldBeFalse()
        {
            string userId = UserEditor.Id.ToString();
            string bookId = Book1.Id.ToString();

            bool hasBook = await this.userService.UserHasBookAsFavouriteAsync(bookId, userId);

            Assert.IsFalse(hasBook);
        }

        [Test]
        public async Task UserHasBooksInFvouriteShouldReturnTrue()
        {
            string userId = NonActiveEditor.Id.ToString();
            string bookId = Book1.Id.ToString();

            bool hasBook = await this.userService.UserHasBookAsFavouriteAsync(bookId, userId);

            Assert.IsTrue(hasBook);
        }

        [Test]
        public async Task RemovingUserShouldBeCorrect()
        {
            string userId = NormalUser.Id.ToString();
            bool isEditor = false;

            await this.userService.RemoveUserAsync(userId, isEditor);

            bool userExist = this.dbContext.Users.Any(u => u.Id.ToString() == userId);

            Assert.IsFalse(userExist);
        }
    }
}
