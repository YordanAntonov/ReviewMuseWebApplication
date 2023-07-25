namespace ReviewMuse.Services.UserService
{
    using System.Threading.Tasks;
    using ReviewMuse.Data;
    using ReviewMuse.Data.Models.MappingTables;
    using ReviewMuse.Services.Contracts;
    using ReviewMuse.Web.Models.ExportModels;

    public class UserService : IUserService
    {
        private readonly ReviewMuseDbContext dbContext;

        public UserService(ReviewMuseDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddToCollectionAsync(ExpoSingleBookViewModel model, string userId)
        {

            int bookStatus = (int)model.BookStatus;

            UsersBooks userBook = new UsersBooks()
            {
                ApplicationUserId = Guid.Parse(userId),
                BookId = Guid.Parse(model.BookId!),
                BookStatusId = bookStatus
            };

            await this.dbContext.UsersBooks.AddAsync(userBook);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
