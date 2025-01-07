using KeyphPro.Domain.Entities.Commond;

namespace KeyphPro.Domain.Repositories.Queries
{
    using System.Linq.Expressions;

    /// <summary>
    /// Interface for query repositories
    /// </summary>
    /// <typeparam name="TEntity">
    /// The entity type
    /// </typeparam>
    public interface IQueryRepository<TEntity, TId> where TEntity : class, IEntityBase<TId>
    {
        /// <summary>
        /// Get an entity by its id
        /// </summary>
        /// <param name="id">
        /// The id of the entity to get
        /// </param>
        /// <returns>
        /// The entity with the given id
        /// </returns>
        Task<TEntity?> GetByIdAsync(TId id);
        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns>
        /// All entities
        /// </returns>
        Task<IEnumerable<TEntity>> GetAllAsync();
        /// <summary>
        /// Gets the single by query asynchronous.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>
        /// Returns the entities that meet the parameter predicate
        /// </returns>
        Task<TEntity?> GetSingleByQueryAsync(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// Gets the by query asynchronous.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>
        /// Returns the entity that meet the parameter predicate
        /// </returns>
        Task<IEnumerable<TEntity>> GetByQueryAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
