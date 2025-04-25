using LMS.DTOs;
using LMS.Models.Courses;
using LMS.Repositories.Interfaces;
using System.Linq.Expressions;

namespace LMS.Services.Interfaces
{
    public interface ICoursesServies
    {
        Task<IEnumerable<CourseDto>> GetAllCoursesAsync();
        Task<CourseDto> GetCourseByIdAsync(int id);
        Task<Course> AddCourseAsync(CourseCreateDto course);
        Task UpdateCourseAsync(int id,CourseUpdateDto course);
        Task DeleteCourseAsync(int id);
        Task<IEnumerable<CourseDto>> FindCoursesAsync(Expression<Func<Course, bool>> predicate);
        Task<IEnumerable<CourseDto>> GetCoursesWithCategoryIdAsync(int id);
    }
}
