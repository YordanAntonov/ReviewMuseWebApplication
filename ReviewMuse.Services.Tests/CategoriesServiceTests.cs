namespace ReviewMuse.Services.Tests
{
    using Microsoft.EntityFrameworkCore;
    using ReviewMuse.Data;
    using ReviewMuse.Services.CategoryService;
    using ReviewMuse.Services.Contracts;
    using static DatabaseSeeder;

    public class CategoriesServiceTests
    {
        private DbContextOptions<ReviewMuseDbContext> dbOptions;
        private ReviewMuseDbContext dbContext;

        private ICategoryService categoriesService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<ReviewMuseDbContext>()
                .UseInMemoryDatabase("ReviewMuseInMemory" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new ReviewMuseDbContext(this.dbOptions);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.categoriesService = new CategoryService(this.dbContext);
        }

        [Test]
        public async Task GetCategoryByIdAsyncShouldReturnTrue()
        {
            int categoryId = Category1.Id;

            bool categoryExist = await this.categoriesService.CategoryExistByIdAsync(categoryId);

            Assert.IsTrue(categoryExist);
        }

        [Test]
        public async Task GetCategoryByIdShouldReturnFalse()
        {
            int categoryId = 999;

            bool categoryExist = await this.categoriesService.CategoryExistByIdAsync(categoryId);

            Assert.IsFalse(categoryExist);
        }

        [Test]
        public async Task AllCategoriesAsyncShouldReturnCorrectAmountCategory()
        {
            int expectedCount = 53;

            var categories = await this.categoriesService.AllCategoriesAsync();

            int actualCount = categories.Count();

            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }

        [Test]
        public async Task GetCategoryByIdShouldReturnCorrectCategory()
        {
            string expectedCategoryName = "Drama";

            var category = await this.categoriesService.GetCategoryByIdAsync(100);

            Assert.That(category.CategoryName, Is.EqualTo(expectedCategoryName));
        }
    }
}
