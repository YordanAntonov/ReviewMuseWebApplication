using ReviewMuse.Web.Models.Enums;

namespace ReviewMuse.Web.Models.ExportModels
{
    public class ExpoMyBooksCollectionView
    {
        public string BookId { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string? ImageUrl { get; set; }

        public IEnumerable<GetAuthorView> AuthorsNames = null!;

    }
}
