namespace ReviewMuse.Services.Contracts
{
    using ReviewMuse.Services.Models.Book;

    using ReviewMuse.Web.Models.ExportModels;
    using ReviewMuse.Web.Models.ImportModels;

    public interface IBookService
    {
        Task AddBook(ImpoNewBookViewModel model, string editorId);
        Task AddRatingToBookAsync(int rating, string bookId);

        Task<bool> BookExistsById(string id);

        Task<ExpoSingleBookViewModel> GetBookByIdAsync(string id);

        Task<AllBooksSearchEngineModel> AllAsync(ExpoAllBooksQueryViewModel queryModel);

        Task<IEnumerable<ImpoCoverTypeViewModel>> GetBookCoversAsync();

        Task<IEnumerable<ImpoLanguageViewModel>> GetBookLanguagesAsync();


    }
}
