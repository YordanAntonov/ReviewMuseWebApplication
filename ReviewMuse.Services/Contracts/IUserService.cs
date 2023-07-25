using ReviewMuse.Web.Models.ExportModels;

namespace ReviewMuse.Services.Contracts
{
    public interface IUserService
    {
        Task AddToCollectionAsync(ExpoSingleBookViewModel model, string userId);
    }
}
