namespace ReviewMuse.Web.Models.ExportModels
{
    public class ExpoCategoryViewModel
    {
        public ExpoCategoryViewModel()
        {
            this.Books = new HashSet<ExpoPartialBookViewModel>();
        }

        public int Id { get; set; }

        public string? CategoryName { get; set; }

        public string? Description { get; set; }

        public IEnumerable<ExpoPartialBookViewModel> Books { get; set; } = null!;
    }
}
