using LMS.Models.Context;
using LMS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace LMS.Repositories.Implementions
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }


        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }


        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
        }


        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }
    }
}
