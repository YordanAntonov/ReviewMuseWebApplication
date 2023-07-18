namespace ReviewMuse.Services.Contracts
{
    using System.Collections.Generic;
    public interface ICategoryService
    {
        Task<IEnumerable<string>> AllCategoriesAsync();
    }
}
