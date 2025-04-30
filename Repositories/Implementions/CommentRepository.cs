using LMS.Models.Context;
using LMS.Models.Social;
using LMS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LMS.Repositories.Implementions
{
    public class CommentRepository:GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Comment>> GetAllCommentByCourseIdDiscussionID(int discussionId, int courseId)
        {
            return await _dbSet
                .Include(c => c.Discussion)
                .Include(c => c.User)
                .Where(c => c.DiscussionId == discussionId && c.Discussion.CourseId == courseId)
                .ToListAsync();
        }
    }

}
