using Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Backend.Core.Data.Ef
{
    public class EfRepository<TEntity>
        : IEntityRepository<TEntity>
        where TEntity :
        class,
        IEntity,
        new()
    {
        private readonly DbContext _context;
        public EfRepository(DbContext context) { _context = context; }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            await _context.SaveChangesAsync();
            return addedEntity.Entity;
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            try
            {
                var addedEntity = _context.Entry(entity);
                addedEntity.State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            return true;
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return  filter == null ? await _context.Set<TEntity>().ToListAsync()
                    : await _context.Set<TEntity>().Where(filter).ToListAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return addedEntity.Entity;
        }
    }
}
