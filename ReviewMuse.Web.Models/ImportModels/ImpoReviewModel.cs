namespace ReviewMuse.Web.Models.ImportModels
{
    using System.ComponentModel.DataAnnotations;

    using static ReviewMuse.Common.EntityValidationConstraints.Review;

    public class ImpoReviewModel
    {
        [Required]
        [StringLength(ReviewCommentMaxLength, MinimumLength = ReviewCommentMinLength, ErrorMessage = "The minimum length of the review should be {2} and the maximum length should be {1} characters.")]
        public string Comment { get; set; } = null!;

        [Required]
        [Range(ReviewRatingMinRate, ReviewRatingMaxRate, ErrorMessage = "The rating should be from 1 to 5")]
        public int Rating { get; set; }
    }
}
