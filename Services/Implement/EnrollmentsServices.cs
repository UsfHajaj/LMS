using AutoMapper;
using LMS.DTOs;
using LMS.Models.Interaction;
using LMS.Repositories.Interfaces;
using LMS.Services.Interfaces;

namespace LMS.Services.Implement
{
    public class EnrollmentsServices:IEnrollmentsServices
    {
        private readonly IEnrollmentsRepository _repository;
        private readonly IMapper _mapper;

        public EnrollmentsServices(IEnrollmentsRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<EnrollmentDto> GetEnrollmentByIdAsync(int id)
        {
            var enrolment = await _repository.EnrollmentById(id);
            return _mapper.Map<EnrollmentDto>(enrolment);
        }

        public async Task<EnrollmentDto> GetEnrollmentByStudentIdAndCourseIdAsync(string studentId, int courseId)
        {
            var enrollment = await _repository.EnrollmentByStudentIdAndCourseId(studentId, courseId);
            return _mapper.Map<EnrollmentDto>(enrollment);
        }

        public async Task<IEnumerable<EnrollmentDto>> GetEnrollmentsByCourseIdAsync(int courseId)
        {
            var enrollments =await _repository.EnrollmentsByCourseId(courseId);
            return _mapper.Map<IEnumerable<EnrollmentDto>>(enrollments);
        }

        public async Task<IEnumerable<EnrollmentDto>> GetEnrollmentsByStudentIdAsync(string studentId)
        {
            var enrollments =await _repository.EnrollmentsByStudentId(studentId);
            return _mapper.Map<IEnumerable<EnrollmentDto>>(enrollments);
        }
        public async Task<EnrollmentDto> AddEnrollmentAsync(UpdateEnrollmentDto enrollmentDto)
        {
            var enrollment = _mapper.Map<Enrollment>(enrollmentDto);
            await _repository.AddAsync(enrollment);
            await _repository.SaveChangesAsync();
            return _mapper.Map<EnrollmentDto>(enrollment);
        }
        public async Task UpdateEnrollmentAsync(int id,UpdateEnrollmentDto model)
        {
            var enrollment = await _repository.GetByIdAsync(id);

            _mapper.Map(model, enrollment);
            await _repository.SaveChangesAsync();
        }
        public async Task DeleteEnrollmentAsync(int id)
        {
            var enrollment = await _repository.GetByIdAsync(id);

            await _repository.DeleteAsync(enrollment);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<EnrollmentDto>> GetAllEnrollmentsAsync()
        {
            var enrollments =await _repository.GetAllEnrollment();
            return _mapper.Map<IEnumerable<EnrollmentDto>>(enrollments);
        }
    }
}
