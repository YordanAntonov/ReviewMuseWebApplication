namespace ReviewMuse.Services.Contracts
{
    using ReviewMuse.Web.Models.ExportModels;
    using ReviewMuse.Web.Models.ImportModels;

    public interface IAuthorService
    {
        Task<ExpoAuthorPageViewModel> GetAuthorByIdAsync(string id);

        Task<bool> AuthorExistByIdAsync(string id);

        Task<IEnumerable<ExpoAuthorForAddingNewBookView>> GetAuthorForAddingBookAsync();

        Task AddAuthorAsync(ImpoNewAuthorViewModel model);
    }
}
