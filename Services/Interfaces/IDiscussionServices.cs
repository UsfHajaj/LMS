using LMS.DTOs;

namespace LMS.Services.Interfaces
{
    public interface IDiscussionServices
    {
        Task<IEnumerable<DiscussionDto>> GetAllDiscussionsAsync();
        Task<DiscussionDto> GetDiscussionByIdAsync(int id);
        Task<IEnumerable<DiscussionDto>> GetDiscussionsByCourseIdAsync(int courseId);
        Task<IEnumerable<DiscussionDto>> GetDiscussionsByUserIdAsync(string userId);
        Task<IEnumerable<DiscussionDto>> GetDiscussionsByCategoryIdAsync(int categoryId);
        Task<IEnumerable<DiscussionDto>> GetDiscussionsByCourseIdAndUserIdAsync(int courseId, string userId);
        Task<IEnumerable<commentDto>> GetAllCommentByCourseIdDiscussionIDAsync(int discussionId, int courseId);
        Task<EditCommentDto> AddCommentAsync(EditCommentDto comment, int discussionId, int courseId,string userId);
        Task<DiscussionDto> AddDiscussionAsync(EditDiscussionDto discussion,string userId);
        Task UpdateDiscussionAsync(int id, EditDiscussionDto discussion);
        Task DeleteDiscussionAsync(int id);
    }
}
