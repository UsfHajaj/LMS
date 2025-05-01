using AutoMapper;
using LMS.DTOs;
using LMS.Models.Interaction;
using LMS.Repositories.Interfaces;
using LMS.Services.Interfaces;

namespace LMS.Services.Implement
{
    public class ProgressServies : IProgressServies
    {
        private readonly IProgressRepository _repository;
        private readonly IMapper _mapper;

        public ProgressServies(IProgressRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProgressDto>> GetProgressByCourseIdAsync(int courseId)
        {
            var progress =await _repository.GetProgressByCourseIdAsync(courseId);
            return _mapper.Map<IEnumerable<ProgressDto>>(progress);
        }

        public async Task<ProgressDto> GetProgressByIdAsync(int id)
        {
            var progress =await _repository.GetByIdAsync(id);
            return _mapper.Map<ProgressDto>(progress);
        }

        public async Task<IEnumerable<ProgressDto>> GetProgressByUserIdAsync(string userId)
        {
            var progress =await _repository.GetProgressByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<ProgressDto>>(progress);
        }
        public async Task<ProgressDto> AddProgressAsync(string studentId, bool IsCompleted, EditProgressDto progress)
        {
            var progressentity = _mapper.Map<Progress>(progress);
            progressentity.StudentId = studentId;
            progressentity.IsCompleted = IsCompleted;
            await _repository.AddAsync(progressentity);
            await _repository.SaveChangesAsync();
            return _mapper.Map<ProgressDto>(progressentity);
        }

        public async Task DeleteProgressAsync(int id)
        {
            var progress =await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(progress);
            await _repository.SaveChangesAsync();
        }

        

        public async Task UpdateProgressAsync(int id, string studentId, bool IsCompleted, EditProgressDto progress)
        {
            var progressentity= await _repository.GetByIdAsync(id);

            _mapper.Map(progress, progressentity);

            progressentity.StudentId = studentId;
            progressentity.IsCompleted = IsCompleted;

            await _repository.SaveChangesAsync();
        }

        public async Task<ProgressDto> GetProgressByCourseIdAndLessonIdAsync(int courseId, int lessonId)
        {
            var progress = await _repository.GetProgressByCourseIdAndLessonId(courseId, lessonId);

            return _mapper.Map<ProgressDto>(progress);
        }
    }
}
