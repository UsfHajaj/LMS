using AutoMapper;
using LMS.DTOs;
using LMS.Models.Courses;
using LMS.Repositories.Interfaces;
using LMS.Services.Interfaces;

namespace LMS.Services.Implement
{
    public class LessonService:ILessonService
    {
        private readonly ILessonRepository _repository;
        private readonly IMapper _mapper;

        public LessonService(ILessonRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<LessonDto> GetLessonById(int lessonId)
        {
            var lesson =await _repository.GetLessonWithDetails(lessonId);
            return _mapper.Map<LessonDto>(lesson);
        }

        public async Task<IEnumerable<LessonDto>> GetLessonsByModuleId(int courseID,int moduleId)
        {
            var lessons =await _repository.GetLessonsByModuleId(courseID,moduleId);
            return _mapper.Map<IEnumerable<LessonDto>>(lessons);
        }

        public async Task<LessonDto> CreateLesson(EditLessonDto lessonDto)
        {
            var lesson = _mapper.Map<Lesson>(lessonDto);
            await _repository.AddAsync(lesson);
            await _repository.SaveChangesAsync();
            return _mapper.Map<LessonDto>(lesson);
        }


        

        public async Task UpdateLesson(int lessonId, EditLessonDto lessonDto)
        {
            var lesson =await _repository.GetByIdAsync(lessonId);
            _mapper.Map(lessonDto, lesson);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteLesson(int lessonId)
        {
            var lesson =await _repository.GetByIdAsync(lessonId);
            await _repository.DeleteAsync(lesson);
            await _repository.SaveChangesAsync();
        }
    }
}
