using LMS.Models.Context;
using LMS.Models.Courses;
using LMS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LMS.Repositories.Implementions
{
    public class ModulesRepository : GenericRepository<Modules>, IModulesRepository
    {
        public ModulesRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Modules>> GetAllModules()
        {
            var modules = await _dbSet
                .Include(m => m.Course)
                .Include(m => m.Lessons)
                .Include(m => m.Quizzes)
                .ToListAsync();
            return modules;
        }

        public async Task<Modules> GetModulesById(int id)
        {
            return await _dbSet
                .Include(m => m.Course)
                .Include(m => m.Lessons)
                .Include(m => m.Quizzes)
                .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
