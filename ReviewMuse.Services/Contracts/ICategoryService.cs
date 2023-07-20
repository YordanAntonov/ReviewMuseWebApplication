namespace ReviewMuse.Services.Contracts
{
    using ReviewMuse.Web.Models.ExportModels;
    using System.Collections.Generic;
    public interface ICategoryService
    {
        Task<IEnumerable<string>> AllCategoriesAsync();
    }
}
