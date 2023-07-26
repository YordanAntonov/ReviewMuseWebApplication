namespace ReviewMuse.Services.Contracts
{
    using ReviewMuse.Services.Models.Book;
    using ReviewMuse.Web.Models.ExportModels;
    public interface IUserService
    {
        Task AddToCollectionAsync(ExpoSingleBookViewModel model, string userId);

        Task<MyCollectionBookEngineModel> MyCollectionAsync(ExpoMyBooksCollectionQueryModel queryModel, string userId);

    }
}
