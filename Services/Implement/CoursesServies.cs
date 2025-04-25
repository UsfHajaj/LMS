using AutoMapper;
using LMS.DTOs;
using LMS.Models.Courses;
using LMS.Repositories.Interfaces;
using LMS.Services.Interfaces;
using System.Linq.Expressions;

namespace LMS.Services.Implement
{
    public class CoursesServies:ICoursesServies
    {
        private readonly ICoursesRepository _repository;
        private readonly IMapper _mapper;

        public CoursesServies(ICoursesRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CourseDto>> GetAllCoursesAsync()
        {
            return await _repository.GetAllCourses();
        }

        public async Task<CourseDto> GetCourseByIdAsync(int id)
        {
            return await _repository.CourseByIdAsync(id);
        }
        public async Task<IEnumerable<CourseDto>> FindCoursesAsync(Expression<Func<Course, bool>> predicate)
        {
            return await _repository.FindCourses(predicate);
        }

        public async Task<IEnumerable<CourseDto>> GetCoursesWithCategoryIdAsync(int id)
        {
            return await _repository.CoursesWithCategoryIdAsync(id);
        }


        public async Task<Course> AddCourseAsync(CourseCreateDto coursedto)
        {
            var course= _mapper.Map<Course>(coursedto);
            course.CreatedAt = DateTime.UtcNow;
            course.UpdatedAt = DateTime.UtcNow;
            await _repository.AddAsync(course);
            await _repository.SaveChangesAsync();
            return course;
        }

        public async Task UpdateCourseAsync(int id,CourseUpdateDto coursedto)
        {
            var course =await _repository.GetByIdAsync(id);

            _mapper.Map(coursedto, course);

            course.UpdatedAt = DateTime.UtcNow;

            await _repository.SaveChangesAsync();
        }
        public async Task DeleteCourseAsync(int id)
        {
            var corses = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(corses);
            await _repository.SaveChangesAsync();
        }
    }
}
