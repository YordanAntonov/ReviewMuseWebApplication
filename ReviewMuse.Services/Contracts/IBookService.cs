namespace ReviewMuse.Services.Contracts
{
    using ReviewMuse.Services.Models.Book;

    using ReviewMuse.Web.Models.ExportModels;

    public interface IBookService
    {
        Task AddRatingToBookAsync(int rating, string bookId);

        Task<bool> BookExistsById(string id);

        Task<ExpoSingleBookViewModel> GetBookByIdAsync(string id);

        Task<AllBooksSearchEngineModel> AllAsync(ExpoAllBooksQueryViewModel queryModel);


    }
}
