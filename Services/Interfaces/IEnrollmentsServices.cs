using LMS.DTOs;
using LMS.Models.Interaction;

namespace LMS.Services.Interfaces
{
    public interface IEnrollmentsServices
    {
        Task<IEnumerable<EnrollmentDto>> GetAllEnrollmentsAsync();
        Task<EnrollmentDto> GetEnrollmentByStudentIdAndCourseIdAsync(string studentId, int courseId);
        Task<EnrollmentDto> GetEnrollmentByIdAsync(int id);
        Task<IEnumerable<EnrollmentDto>> GetEnrollmentsByStudentIdAsync(string studentId);
        Task<IEnumerable<EnrollmentDto>> GetEnrollmentsByCourseIdAsync(int courseId);
        Task<EnrollmentDto> AddEnrollmentAsync(UpdateEnrollmentDto enrollment);
        Task UpdateEnrollmentAsync(int id,UpdateEnrollmentDto enrollment);
        Task DeleteEnrollmentAsync(int id);
    }
}
