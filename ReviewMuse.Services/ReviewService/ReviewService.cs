namespace ReviewMuse.Services.ReviewService
{
    using Microsoft.EntityFrameworkCore;
    using ReviewMuse.Data;
    using ReviewMuse.Data.Models;
    using ReviewMuse.Services.Contracts;
    using ReviewMuse.Web.Models.ExportModels;

    using System.Collections.Generic;

    public class ReviewService : IReviewService
    {
        private readonly ReviewMuseDbContext dbContext;
        public ReviewService(ReviewMuseDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> BookHasReviewsAsync(string bookId)
        {
            return await this.dbContext
                             .Reviews.AnyAsync(r => r.BookId.ToString() == bookId);
        }

        public async Task<IEnumerable<ExpoReviewModel>> GetAllReviewsAsync(string bookId)
        {
            IEnumerable<ExpoReviewModel> reviews = await dbContext
                .Reviews
                .Where(b => b.BookId.ToString() == bookId)
                .OrderByDescending(r => r.PostedOn)
                .Select(r => new ExpoReviewModel()
                {
                    Rating = r.Rating,
                    Comment = r.Comment,
                    DatePublished = r.PostedOn.ToString("dd MMM yyyy"),
                    Username = r.User.UserName
                })
                .ToListAsync();

            return reviews;
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
