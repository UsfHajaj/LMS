using LMS.Models.Courses;
using System.Reflection;

namespace LMS.Models.Interaction
{
    public class Quiz
    {
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int TimeLimit { get; set; } 
        public int PassingScore { get; set; }
        public bool IsActive { get; set; }

        public virtual Modules Module { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
