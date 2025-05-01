using System.ComponentModel.DataAnnotations;

namespace LMS.DTOs
{
    public class GradeSubmissionDto
    {
        [Required]
        [Range(0, 100)]
        public int Score { get; set; }

        public string Feedback { get; set; }
    }
}
