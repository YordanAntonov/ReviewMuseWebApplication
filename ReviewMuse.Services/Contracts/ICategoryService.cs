namespace ReviewMuse.Services.Contracts
{
    using ReviewMuse.Web.Models.ExportModels;
    using System.Collections.Generic;
    public interface ICategoryService
    {
        Task<IEnumerable<string>> AllCategoriesAsync();

        Task<ExpoCategoryViewModel> GetCategoryByIdAsync(int id);

        Task<bool> CategoryExistByIdAsync(int id);
    }
}
