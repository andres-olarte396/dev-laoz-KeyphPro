using KeyphPro.Domain.Entities.Commond;
using KeyphPro.Domain.Repositories.Commands;
using KeyphPro.Domain.Repositories.Queries;

namespace KeyphPro.Domain.Repositories
{
    /// <summary>
    /// Interface for unit of work
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Commands the repository.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <typeparam name="TId">The type of the identifier.</typeparam>
        /// <returns>
        /// The command repository
        /// </returns>
        ICommandRepository<TEntity, TId> CommandRepository<TEntity, TId>() where TEntity : class, IEntityBase<TId>;
        /// <summary>
        /// Queries the repository.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <typeparam name="TId">The type of the identifier.</typeparam>
        /// <returns>
        /// The query repository
        /// </returns>
        IQueryRepository<TEntity, TId> QueryRepository<TEntity, TId>() where TEntity : class, IEntityBase<TId>;
        /// <summary>
        /// Saves the changes asynchronous.
        /// </summary>
        /// <returns>
        /// The number of affected rows
        /// </returns>
        Task<int> SaveChangesAsync();
    }
}
