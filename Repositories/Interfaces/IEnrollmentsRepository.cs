using LMS.Models.Interaction;

namespace LMS.Repositories.Interfaces
{
    public interface IEnrollmentsRepository:IGenericRepository<Enrollment>
    {
        Task<Enrollment> EnrollmentByStudentIdAndCourseId(string studentId, int courseId);
        Task<IEnumerable<Enrollment>> EnrollmentsByStudentId(string studentId);
        Task<IEnumerable<Enrollment>> EnrollmentsByCourseId(int courseId);
        Task<bool> IsEnrolled(string studentId, int courseId);
        Task<bool> IsCompleted(string studentId, int courseId);

    }
}
