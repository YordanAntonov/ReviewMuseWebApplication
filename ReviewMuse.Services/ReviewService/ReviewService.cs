namespace ReviewMuse.Services.ReviewService
{
    using ReviewMuse.Data;
    using ReviewMuse.Data.Models;
    using ReviewMuse.Services.Contracts;
    using ReviewMuse.Web.Models.ExportModels;
    public class ReviewService : IReviewService
    {
        private readonly ReviewMuseDbContext dbContext;
        public ReviewService(ReviewMuseDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task SaveReviewAsync(ExpoSingleBookViewModel model, string userId)
        {
            Review review = new Review()
            {
                Id = Guid.NewGuid(),
                BookId = Guid.Parse(model.BookId),
                UserId = Guid.Parse(userId),
                Rating = model.UserReview.Rating,
                Comment = model.UserReview.Comment
            };

            await dbContext.Reviews.AddAsync(review);
            await dbContext.SaveChangesAsync();
        }
    }
}
