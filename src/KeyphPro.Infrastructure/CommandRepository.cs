using Microsoft.EntityFrameworkCore;
using KeyphPro.Domain.Entities.Commond;
using KeyphPro.Domain.Repositories.Commands;

namespace KeyphPro.Infrastructure
{
    /// <summary>
    /// Command Repository
    /// </summary>
    /// <typeparam name="TEntity">
    /// Entity
    /// </typeparam>
    /// <typeparam name="TId">
    /// Id of the entity
    /// </typeparam>
    public class CommandRepository<TEntity, TId> : ICommandRepository<TEntity, TId> where TEntity : class, IEntityBase<TId>
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">
        /// StoreDBContext
        /// </param>
        public CommandRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">
        /// Entity to update
        /// </param>
        /// <returns>
        /// True if the entity was updated
        /// </returns>
        public async Task<bool> UpdateAsync(TEntity entity)
        {
            return await Task.Run(() =>
             {
                 _context.Entry(entity).State = EntityState.Modified;
                 return true;
             });
        }
        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">
        /// Entity to delete
        /// </param>
        /// <returns>
        /// True if the entity was deleted
        /// </returns>
        public async Task<bool> DeleteAsync(TEntity entity)
        {
            return await Task.Run(() =>
            {
                entity.Deleted = true;
                _context.Entry(entity).State = EntityState.Modified;
                return entity.Deleted;
            });
        }
        /// <summary>
        /// Create entity
        /// </summary>
        /// <param name="entity">
        /// Entity to create
        /// </param>
        /// <returns>
        /// Id of the entity created
        /// </returns>
        public async Task<TId> CreateAsync(TEntity entity)
        {
            return await Task.Run(() =>
            {
                _context.Add(entity);
                return entity.Id;
            });
        }
        /// <summary>
        /// Saves the changes.
        /// </summary>
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
