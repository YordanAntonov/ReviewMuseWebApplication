using ReviewMuse.Web.Models.ExportModels;

namespace ReviewMuse.Services.Models.Book
{
    public class MyCollectionBookEngineModel
    {
        public MyCollectionBookEngineModel()
        {
            this.Books = new HashSet<ExpoMyBooksCollectionView>();
        }

        public int TotalBooksCount { get; set; }

        public IEnumerable<ExpoMyBooksCollectionView> Books { get; set; } = null!;
    }
}
