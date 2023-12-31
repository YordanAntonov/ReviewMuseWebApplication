﻿using ReviewMuse.Web.Models.ExportModels;
using ReviewMuse.Web.Models.ImportModels;

namespace ReviewMuse.Services.Contracts
{
    public interface IEditorService
    {
        Task<bool> IsUserEditorById(Guid id);
        Task<bool> IsUserEditorByIdNonActive(Guid id);

        Task<string> GetEditorIdViaUserIdAsync(Guid userId);

        Task<IEnumerable<ExpoPartialBookViewModel>> GetEditorBooksAsync(string editorId);

        Task AddNewLanguage(ImpoLanguageViewModel model);

        Task AddNewCoverType(ImpoCoverTypeViewModel model);

        Task<ImpoNewBookViewModel> GetEditBookAsync(string bookId);

        Task EditBookAsync(ImpoNewBookViewModel model);

        Task<ImpoNewAuthorViewModel> GetEditAuthorAsync(string authorId);

        Task EditAuthorAsync(ImpoNewAuthorViewModel model);

        Task BecomeEditorAsync(ImpoNewEditorViewModel model);

        Task RemoveBookAsync(string id);

        Task RemoveEditor(string id);
    }
}
