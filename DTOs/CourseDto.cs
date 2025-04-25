using LMS.Models.Enums;

namespace LMS.DTOs
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ThumbnailUrl { get; set; }
        public decimal Price { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsPublished { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Language { get; set; }
        public CourseLevels Level { get; set; }
        public string InstructorName { get; set; }
        public string CategoryName { get; set; }
        public double Rating { get; set; }
        public int EnrollmentCount { get; set; }
    }
}
