namespace ReviewMuse.Services.Contracts
{
    using ReviewMuse.Web.Models.ExportModels;

    public interface IBookService
    {
        Task<IEnumerable<ExpoAllBooksViewModel>> GetAllBooksAsync();
    }
}
