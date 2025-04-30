using LMS.Models.Interaction;

namespace LMS.Models.Courses
{
    public class Modules
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }

        public virtual Course Course { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual ICollection<Quiz> Quizzes { get; set; }
    }
}
