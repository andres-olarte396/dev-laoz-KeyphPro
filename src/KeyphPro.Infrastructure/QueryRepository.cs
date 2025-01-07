using KeyphPro.Domain.Entities.Commond;
using KeyphPro.Domain.Repositories.Queries;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KeyphPro.Infrastructure
{
    /// <summary>
    /// Query repository
    /// </summary>
    /// <typeparam name="TEntity">
    /// The entity type
    /// </typeparam>
    /// <typeparam name="TId">
    /// The id type
    /// </typeparam>
    public class QueryRepository<TEntity, TId> : IQueryRepository<TEntity, TId> where TEntity : class, IEntityBase<TId>
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">
        /// The database context
        /// </param>
        public QueryRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        /// <summary>
        /// Get an entity by its id
        /// </summary>
        /// <param name="id">
        /// The id of the entity to get
        /// </param>
        /// <returns>
        /// The entity with the given id
        /// </returns>
        public async Task<TEntity?> GetByIdAsync(TId id)
        {
            return await Task.Run(() =>
            {
                TEntity? entity = _dbSet.Find(id);
                return entity?.Deleted == true ? default : entity;
            });
        }

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns>
        /// All entities
        /// </returns>
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Task.Run(() =>
            {
                return _dbSet.Where(x => !x.Deleted).AsEnumerable();
            });
        }

        /// <summary>
        /// Get entities by a dynamic query
        /// </summary>
        /// <param name="predicate">
        /// The expression to filter the entities
        /// </param>
        /// <returns>
        /// A list of filtered entities
        /// </returns>
        public async Task<IEnumerable<TEntity>> GetByQueryAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Task.Run(() =>
            {
                return _dbSet.Where(predicate).Where(x => !x.Deleted).AsEnumerable();
            });
        }

        /// <summary>
        /// Get a single entity by a dynamic query
        /// </summary>
        /// <param name="predicate">
        /// The expression to filter the entity
        /// </param>
        /// <returns>
        /// A single entity matching the query
        /// </returns>
        public async Task<TEntity?> GetSingleByQueryAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Task.Run(() =>
            {
                return _dbSet.Where(predicate).FirstOrDefault(x => !x.Deleted);
            });
        }
    }
}
