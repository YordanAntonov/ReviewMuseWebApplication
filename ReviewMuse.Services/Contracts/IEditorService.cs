namespace ReviewMuse.Services.Contracts
{
    public interface IEditorService
    {
        Task<bool> IsUserEditorById(Guid id);
    }
}
