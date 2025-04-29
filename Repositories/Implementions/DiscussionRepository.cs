using AutoMapper;
using LMS.Models.Context;
using LMS.Models.Social;
using LMS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LMS.Repositories.Implementions
{
    public class DiscussionRepository : GenericRepository<Discussion>, IDiscussionRepository
    {
        public DiscussionRepository(ApplicationDbContext context) : base(context)
        {
        }

       

        public async Task<IEnumerable<Discussion>> GetAllDiscussions()
        {
            return await _dbSet
                .Include(d => d.Comments)
                .Include(d => d.Course)
                .ToListAsync();
        }

        public async Task<Discussion> GetDiscussionById(int id)
        {
            return await _dbSet
                .Include(d => d.Comments)
                .Include(d => d.Course)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<Discussion>> GetDiscussionsByCategoryId(int categoryId)
        {
            return await _dbSet
                .Include(d => d.Comments)
                .Include(d => d.Course)
                .Where(d => d.Course.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Discussion>> GetDiscussionsByCourseId(int courseId)
        {
            return await _dbSet
                .Include(d => d.Comments)
                .Include(d => d.Course)
                .Where(d => d.CourseId == courseId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Discussion>> GetDiscussionsByCourseIdAndUserId(int courseId, string userId)
        {
            return await _dbSet
                .Include(d => d.Comments)
                .Include(d => d.Course)
                .Where(d => d.CourseId == courseId && d.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Discussion>> GetDiscussionsByUserId(string userId)
        {
            return await _dbSet
                .Include(d => d.Comments)
                .Include(d => d.Course)
                .Where(d => d.UserId == userId)
                .ToListAsync();
        }
    }
}
