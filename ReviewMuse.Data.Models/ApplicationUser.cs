namespace ReviewMuse.Data.Models
{

    using Microsoft.AspNetCore.Identity;
    using ReviewMuse.Data.Models.MappingTables;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.UserBooks = new HashSet<UsersBooks>();
        }

        public virtual ICollection<UsersBooks> UserBooks { get; set; } = null!;
    }
}
