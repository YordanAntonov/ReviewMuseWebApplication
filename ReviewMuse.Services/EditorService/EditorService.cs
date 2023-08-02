namespace ReviewMuse.Services.EditorService
{
    using Microsoft.EntityFrameworkCore;

    using ReviewMuse.Data;
    using ReviewMuse.Data.Models;
    using ReviewMuse.Services.Contracts;
    using ReviewMuse.Web.Models.ImportModels;

    public class EditorService : IEditorService
    {
        private readonly ReviewMuseDbContext dbContext;
        public EditorService(ReviewMuseDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddNewCoverType(ImpoCoverTypeViewModel model)
        {
            BookCover bookCover = new BookCover()
            {
                CoverType = model.CoverName
            };

            await this.dbContext.BookCovers.AddAsync(bookCover);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task AddNewLanguage(ImpoLanguageViewModel model)
        {
            Language language = new Language()
            {
                LanguageName = model.LanguageName
            };

            await this.dbContext.Languages.AddAsync(language);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<string> GetEditorIdViaUserIdAsync(Guid userId)
        {
            var editorId = await this.dbContext
                .Editors
                .FirstAsync(e => e.UserId == userId);

            return editorId.Id.ToString();
        }

        public async Task<bool> IsUserEditorById(Guid id)
        {
            return await this.dbContext
                .Editors
                .AnyAsync(e => e.UserId == id);
        }
    }
}
