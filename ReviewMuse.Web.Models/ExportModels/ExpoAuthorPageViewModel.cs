namespace ReviewMuse.Web.Models.ExportModels
{
    public class ExpoAuthorPageViewModel
    {
        public ExpoAuthorPageViewModel()
        {
            this.Categories = new HashSet<ExpoCategoryViewModel>();
            this.Books = new HashSet<ExpoPartialBookViewModel>();
        }
        public string Id { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string DateOfBirth { get; set; } = null!;

        public string? DateOfDeath { get; set; }

        public string? Website { get; set; }

        public string? ImageUrl { get; set; }

        public string City { get; set; } = null!;

        public string Country { get; set; } = null!;

        public string? Pseudonim { get; set; }

        public IEnumerable<ExpoCategoryViewModel> Categories = null!;

        public IEnumerable<ExpoPartialBookViewModel> Books { get; set; } = null!;
    }
}
