namespace ReviewMuse.Web.Models.ExportModels
{
    public class ExpoCategoryViewModel
    {
        //public ExpoCategoryViewModel()
        //{
        //    this.Books = new HashSet<ExpoPartialBookViewModel>();
        //}

        public int Id { get; set; }

        public string CategoryName { get; set; } = null!;

        public string Description { get; set; } = null!;

        public IEnumerable<ExpoPartialBookViewModel>? Books { get; set; }
    }
}
