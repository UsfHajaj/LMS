using AutoMapper;
using LMS.DTOs;
using LMS.Models.Social;
using LMS.Repositories.Interfaces;
using LMS.Services.Interfaces;

namespace LMS.Services.Implement
{
    public class DiscussionServices : IDiscussionServices
    {
        private readonly IDiscussionRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;

        public DiscussionServices(IDiscussionRepository repository,IMapper mapper,ICommentRepository commentRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _commentRepository = commentRepository;
        }
        public async Task<DiscussionDto> AddDiscussionAsync(EditDiscussionDto discussion,string userId)
        {
            var NewDiscussion = _mapper.Map<Discussion>(discussion);
            NewDiscussion.UserId = userId;
            await _repository.AddAsync(NewDiscussion);
            await _repository.SaveChangesAsync();
            return _mapper.Map<DiscussionDto>(NewDiscussion);
        }

        public async Task DeleteDiscussionAsync(int id)
        {
            var discussion =await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(discussion);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<commentDto>> GetAllCommentByCourseIdDiscussionIDAsync(int discussionId, int courseId)
        {
            var comments =await _commentRepository
                .GetAllCommentByCourseIdDiscussionID(discussionId, courseId);
            return _mapper.Map<IEnumerable<commentDto>>(comments);
        }

        public async Task<IEnumerable<DiscussionDto>> GetAllDiscussionsAsync()
        {
            var discussions =await _repository.GetAllDiscussions();
            return _mapper.Map<IEnumerable<DiscussionDto>>(discussions);
        }

        public async Task<DiscussionDto> GetDiscussionByIdAsync(int id)
        {
            var discussion =await _repository.GetDiscussionById(id);
            return _mapper.Map<DiscussionDto>(discussion);
        }

        public async Task<IEnumerable<DiscussionDto>> GetDiscussionsByCategoryIdAsync(int categoryId)
        {
            var discussions =await _repository.GetDiscussionsByCategoryId(categoryId);
            return _mapper.Map<IEnumerable<DiscussionDto>>(discussions);
        }

        public async Task<IEnumerable<DiscussionDto>> GetDiscussionsByCourseIdAndUserIdAsync(int courseId, string userId)
        {
            var discussions =await _repository.GetDiscussionsByCourseIdAndUserId(courseId, userId);
            return _mapper.Map<IEnumerable<DiscussionDto>>(discussions);
        }

        public async Task<IEnumerable<DiscussionDto>> GetDiscussionsByCourseIdAsync(int courseId)
        {
            var discussion= await _repository.GetDiscussionsByCourseId(courseId);
            return _mapper.Map<IEnumerable<DiscussionDto>>(discussion);
        }

        public async Task<IEnumerable<DiscussionDto>> GetDiscussionsByUserIdAsync(string userId)
        {
            var discussions =await _repository.GetDiscussionsByUserId(userId);
            return _mapper.Map<IEnumerable<DiscussionDto>>(discussions);
        }

        public async Task UpdateDiscussionAsync(int id, EditDiscussionDto discussion)
        {
            var existingDiscussion =await _repository.GetByIdAsync(id);
            _mapper.Map(discussion, existingDiscussion);
            await _repository.SaveChangesAsync();
        }

        public async Task<EditCommentDto> AddCommentAsync(EditCommentDto comment, int discussionId, int courseId,string userId)
        {
            var newComment = _mapper.Map<Comment>(comment);
            newComment.DiscussionId = discussionId;
            newComment.UserId=userId;
            await _commentRepository.AddAsync(newComment);
            await _commentRepository.SaveChangesAsync();
            return _mapper.Map<EditCommentDto>(newComment);
        }
    }
}
