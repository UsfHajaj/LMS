using LMS.Models.Enums;

namespace LMS.DTOs
{
    public class CourseUpdateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ThumbnailUrl { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsPublished { get; set; }
        public CourseLevels Level { get; set; }
        public string Language { get; set; }
    }
}
