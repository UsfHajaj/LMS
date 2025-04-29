using LMS.Models.Social;

namespace LMS.Repositories.Interfaces
{
    public interface IDiscussionRepository:IGenericRepository<Discussion>
    {
        Task<IEnumerable<Discussion>> GetAllDiscussions();
        Task<Discussion> GetDiscussionById(int id);
        Task<IEnumerable<Discussion>> GetDiscussionsByCourseId(int courseId);
        Task<IEnumerable<Discussion>> GetDiscussionsByUserId(string userId);
        Task<IEnumerable<Discussion>> GetDiscussionsByCategoryId(int categoryId);
        Task<IEnumerable<Discussion>> GetDiscussionsByCourseIdAndUserId(int courseId, string userId);
        
    }
}
