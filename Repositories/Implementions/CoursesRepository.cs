using AutoMapper;
using LMS.DTOs;
using LMS.Models.Context;
using LMS.Models.Courses;
using LMS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LMS.Repositories.Implementions
{
    public class CoursesRepository:GenericRepository<Course>, ICoursesRepository
    {
        private readonly IMapper _mapper;

        public CoursesRepository(ApplicationDbContext context,IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<CourseDto>> FindCourses(Expression<Func<Course, bool>> predicate)
        {
            var  courses=await _dbSet
                .Include(c => c.Instructor)
                .Include(c => c.Category)
                .Where(predicate)
                .ToListAsync();
            return _mapper.Map<IEnumerable<CourseDto>>(courses);

        }

        public async Task<IEnumerable<CourseDto>> CoursesWithCategoryIdAsync(int id)
        {
            var courses =await _dbSet
                .Include(c => c.Instructor)
                .Include(c => c.Category)
                .Where(m => m.CategoryId == id)
                .ToListAsync();
                return _mapper.Map<IEnumerable<CourseDto>>(courses);
        }

        public async Task<IEnumerable<CourseDto>> GetAllCourses()
        {
            var courses= await _dbSet
                .Include(c => c.Instructor)
                .Include(c => c.Category)
                .ToListAsync();
            return _mapper.Map<IEnumerable<CourseDto>>(courses);
        }

        public async Task<CourseDto> CourseByIdAsync(int id)
        {
            var course =await _dbSet
                .Include(c => c.Instructor)
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            return _mapper.Map<CourseDto>(course);
        }
    }
}
