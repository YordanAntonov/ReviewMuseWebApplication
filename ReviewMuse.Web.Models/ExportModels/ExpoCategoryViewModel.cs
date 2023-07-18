namespace ReviewMuse.Web.Models.ExportModels
{
    public class ExpoCategoryViewModel
    {
        public int Id { get; set; }

        public string CategoryName { get; set; } = null!;

        public string? Description { get; set; }
    }
}
