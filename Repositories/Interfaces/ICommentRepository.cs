using LMS.Models.Social;

namespace LMS.Repositories.Interfaces
{
    public interface ICommentRepository:IGenericRepository<Comment>
    {
        Task<IEnumerable<Comment>> GetAllCommentByCourseIdDiscussionID(int discussionId, int courseId);
    }
}
