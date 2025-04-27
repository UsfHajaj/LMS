using LMS.Models.Context;
using LMS.Models.Interaction;
using LMS.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMS.Repositories.Implementions
{
    public class EnrollmentsRepository:GenericRepository<Enrollment>, IEnrollmentsRepository
    {
        public EnrollmentsRepository(ApplicationDbContext context):base(context)
        {
        }

        public async Task<Enrollment> EnrollmentByStudentIdAndCourseId(string studentId, int courseId)
        {
            var enrollment =await _dbSet
                .Where(e=>e.StudentId == studentId && e.CourseId == courseId)
                .FirstOrDefaultAsync();
            return enrollment;
        }

        public async Task<IEnumerable<Enrollment>> EnrollmentsByCourseId(int courseId)
        {
            var enrollments = await _dbSet
                .Where(m=>m.CourseId == courseId)
                .ToListAsync();
            return enrollments;
        }

        public async Task<IEnumerable<Enrollment>> EnrollmentsByStudentId(string studentId)
        {
            var enrollments = await _dbSet
                .Where(m => m.StudentId == studentId)
                .ToListAsync();
            return enrollments;
        }

        public async Task<bool> IsCompleted(string studentId, int courseId)
        {
            return await _dbSet
                .AnyAsync(e => e.StudentId == studentId 
                && e.CourseId == courseId 
                && e.IsCompleted);
        }

        public async Task<bool> IsEnrolled(string studentId, int courseId)
        {
            return await _dbSet
                .AnyAsync(e => e.StudentId == studentId
                &&e.CourseId==e.CourseId);
        }
    }
}
