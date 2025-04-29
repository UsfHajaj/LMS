using LMS.Models.Social;
using LMS.Repositories.Interfaces;

namespace LMS.Repositories.Implementions
{
    public interface ICommentRepository:IGenericRepository<Comment>
    {
        Task<IEnumerable<Comment>> GetAllCommentByCourseIdDiscussionID(int discussionId, int courseId);
    }
}
