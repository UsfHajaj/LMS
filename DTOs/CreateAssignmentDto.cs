using System.ComponentModel.DataAnnotations;

namespace LMS.DTOs
{
    public class CreateAssignmentDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(1, 100)]
        public int MaxScore { get; set; }

        public string AttachmentUrl { get; set; }

        [Required]
        public DateTime DueDate { get; set; }
    }
}
