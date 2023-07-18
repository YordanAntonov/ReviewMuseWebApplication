namespace ReviewMuse.Services.EditorService
{
    using Microsoft.EntityFrameworkCore;

    using ReviewMuse.Data;
    using ReviewMuse.Services.Contracts;
    public class EditorService : IEditorService
    {
        private readonly ReviewMuseDbContext dbContext;
        public EditorService(ReviewMuseDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> IsUserEditorById(Guid id)
        {
            return await this.dbContext
                .Editors
                .AnyAsync(e => e.UserId == id);
        }
    }
}
