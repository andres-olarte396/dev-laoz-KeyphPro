using KeyphPro.Domain.Entities.Commond;

namespace KeyphPro.Domain.Repositories.Commands
{
    /// <summary>
    /// Interface for command repositories
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    /// <seealso cref="ICreateCommandRepository&lt;TEntity, TId&gt;" />
    /// <seealso cref="IUpdateCommandRepository&lt;TEntity, TId&gt;" />
    /// <seealso cref="IDeleteCommandRepository&lt;TEntity, TId&gt;" />
    public interface ICommandRepository<TEntity, TId> :
        ICreateCommandRepository<TEntity, TId>,
        IUpdateCommandRepository<TEntity, TId>,
        IDeleteCommandRepository<TEntity, TId>
            where TEntity : class, IEntityBase<TId>
    {
        Task SaveChangesAsync();
    }
    /// <summary>
    /// Interface for command repositories
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface ICreateCommandRepository<TEntity, TId> where TEntity : class, IEntityBase<TId>
    {
        /// <summary>
        /// Creates the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>
        /// The id of the created entity
        /// </returns>
        Task<TId> CreateAsync(TEntity entity);
    }
    /// <summary>
    /// Interface for command repositories
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface IUpdateCommandRepository<TEntity, TId> where TEntity : class, IEntityBase<TId>
    {
        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task<bool> UpdateAsync(TEntity entity);

    }
    /// <summary>
    /// Interface for command repositories
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface IDeleteCommandRepository<TEntity, TId> where TEntity : class, IEntityBase<TId>
    {
        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task<bool> DeleteAsync(TEntity entity);
    }
}
