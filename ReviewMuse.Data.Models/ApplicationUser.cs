namespace ReviewMuse.Data.Models
{

    using Microsoft.AspNetCore.Identity;
    using ReviewMuse.Data.Models.MappingTables;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.UserBooks = new HashSet<UsersBooks>();
            this.Editors = new HashSet<Editor>();
            this.Reviews = new HashSet<Review>();
        }

        public virtual ICollection<UsersBooks> UserBooks { get; set; } = null!;

        public virtual ICollection<Editor> Editors { get; set; } = null!;

        public virtual ICollection<Review> Reviews { get; set; } = null!;
    }
}
