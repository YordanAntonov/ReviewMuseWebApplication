using ReviewMuse.Web.Models.ExportModels;

namespace ReviewMuse.Services.Models.Book
{
    public class AllBooksSearchEngineModel
    {
        public AllBooksSearchEngineModel()
        {
            this.Books = new HashSet<ExpoAllBooksViewModel>();
        }

        public int TotalBooksCount { get; set; }

        public IEnumerable<ExpoAllBooksViewModel> Books { get; set; } = null!;
    }
}
