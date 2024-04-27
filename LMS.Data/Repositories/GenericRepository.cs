using LMS.Data.entities;
using Microsoft.EntityFrameworkCore;

namespace LMS.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly LMSDBContext _context;
        private readonly DbSet<T> _dbset;
        public GenericRepository(LMSDBContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }
        public async Task<T> DeleteAsync(int id)
        {
            var entity = await _dbset.FindAsync(id);
            _dbset.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var all = await _dbset.ToListAsync();
            return all;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _dbset.FindAsync(id);
            return entity;
        }

        public async Task<T> InsertAsync(T entity)
        {
            await _dbset.AddRangeAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbset.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
