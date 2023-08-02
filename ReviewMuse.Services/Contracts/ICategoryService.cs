namespace ReviewMuse.Services.Contracts
{
    using ReviewMuse.Web.Models.ExportModels;
    using ReviewMuse.Web.Models.ImportModels;
    using System.Collections.Generic;
    public interface ICategoryService
    {
        Task<IEnumerable<string>> AllCategoriesAsync();

        Task<ExpoCategoryViewModel> GetCategoryByIdAsync(int id);

        Task<bool> CategoryExistByIdAsync(int id);

        Task<IEnumerable<ImpoCategoriesForBookAndAuthorViewModel>> GetCategoriesAsync();

        Task AddCategoryAsync(ImpoNewCategoryViewModel model);
    }
}
