namespace ReviewMuse.Services.Contracts
{
    using ReviewMuse.Web.Models.ExportModels;
    public interface IReviewService
    {
        Task SaveReviewAsync(ExpoSingleBookViewModel model, string userId);

        Task<IEnumerable<ExpoReviewModel>> GetAllReviewsAsync(string bookId);

        Task<bool> BookHasReviewsAsync(string bookId);

        Task RemoveReviewAsync(string id);

        Task<bool> ReviewExistByIdAsync(string id);
    }
}
