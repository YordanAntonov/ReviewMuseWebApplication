namespace ReviewMuse.Services.Contracts
{
    using ReviewMuse.Services.Models.Book;

    using ReviewMuse.Web.Models.ExportModels;

    public interface IBookService
    {
        Task<IEnumerable<ExpoAllBooksViewModel>> GetAllBooksAsync();

        Task<AllBooksSearchEngineModel> AllAsync(ExpoAllBooksQueryViewModel queryModel);
    }
}
