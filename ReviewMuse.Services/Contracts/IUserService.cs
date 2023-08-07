namespace ReviewMuse.Services.Contracts
{
    using ReviewMuse.Data.Models;
    using ReviewMuse.Services.Models.Book;
    using ReviewMuse.Web.Models.ExportModels;
    public interface IUserService
    {
        Task AddToCollectionAsync(ExpoSingleBookViewModel model, string userId);

        Task<MyCollectionBookEngineModel> MyCollectionAsync(ExpoMyBooksCollectionQueryModel queryModel, string userId);

        Task<bool> UserHasBookAsFavouriteAsync(string bookId, string userId);

        Task UpdateToCollectionBookAsync(ExpoSingleBookViewModel model, string userId);

        Task<Web.Models.Enums.BookStatus> GetUserBookStatus(string userId, string bookId);

        Task RemoveFromFavouritesAsync(string bookId, string userId);

        Task<ExpoUserInfoViewModel> GetUserInfoAsync(string userId);

        Task<int> GetUserTotalReviews(string userId);

        Task<int> GetUserTotalStars(string userId);

        Task RemoveUserAsync(string userId, bool isUserEditor);
    }
}
