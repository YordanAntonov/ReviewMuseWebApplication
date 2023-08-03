using System.ComponentModel.DataAnnotations;

namespace ReviewMuse.Web.Models.ImportModels
{
    public class ImpoNewEditorViewModel
    {
        public string? UserId { get; set; }

        [Required]
        [RegularExpression(@"^\d{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2]\d|3[0-1])$", ErrorMessage = "Invalid date format. Use 'yyyy-MM-dd' format.")]
        public string DateOfBirth { get; set; } = null!;

        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = null!;
    }
}
