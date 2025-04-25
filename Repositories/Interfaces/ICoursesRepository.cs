using LMS.DTOs;
using LMS.Models.Courses;
using System.Linq.Expressions;

namespace LMS.Repositories.Interfaces
{
    public interface ICoursesRepository:IGenericRepository<Course>
    {
        Task<IEnumerable<CourseDto>> GetAllCourses();
        Task<CourseDto> CourseByIdAsync(int id);
        Task<IEnumerable<CourseDto>> FindCourses(Expression<Func<Course,bool>> predicate);
        Task<IEnumerable<CourseDto>> CoursesWithCategoryIdAsync(int Id);
    }
}
