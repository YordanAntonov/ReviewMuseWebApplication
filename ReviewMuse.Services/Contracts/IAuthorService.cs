namespace ReviewMuse.Services.Contracts
{
    using ReviewMuse.Web.Models.ExportModels;
    public interface IAuthorService
    {
        Task<ExpoAuthorPageViewModel> GetAuthorByIdAsync(string id);

        Task<bool> AuthorExistByIdAsync(string id);
    }
}
