using ReviewMuse.Web.Models.ImportModels;

namespace ReviewMuse.Services.Contracts
{
    public interface IEditorService
    {
        Task<bool> IsUserEditorById(Guid id);

        Task<string> GetEditorIdViaUserIdAsync(Guid userId);

        Task AddNewLanguage(ImpoLanguageViewModel model);

        Task AddNewCoverType(ImpoCoverTypeViewModel model);
    }
}
