using KeyphPro.Domain.Entities.Commond;
using KeyphPro.Domain.Repositories;
using KeyphPro.Domain.Repositories.Commands;
using KeyphPro.Domain.Repositories.Queries;
using Microsoft.EntityFrameworkCore;

namespace KeyphPro.Infrastructure
{
    /// <summary>
    /// Unit of work
    /// </summary>
    /// <seealso cref="KeyphPro.Infrastructure.IUnitOfWork" />
    public class UnitOfWork(DbContext commandContext, DbContext queryContext) : IUnitOfWork
    {
        private readonly DbContext _commandContext = commandContext;
        private readonly DbContext _queryContext = queryContext;
        private readonly Dictionary<Type, object> _commandRepositories = [];
        private readonly Dictionary<Type, object> _queryRepositories = [];
        /// <summary>
        /// Commands the repository.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <typeparam name="TId">The type of the identifier.</typeparam>
        /// <returns>
        /// ICommandRepository.
        /// </returns>
        public ICommandRepository<TEntity, TId> CommandRepository<TEntity, TId>() where TEntity : class, IEntityBase<TId>
        {
            if (!_commandRepositories.ContainsKey(typeof(TEntity)))
            {
                var repository = new CommandRepository<TEntity, TId>(_commandContext);
                _commandRepositories[typeof(TEntity)] = repository;
            }
            return (ICommandRepository<TEntity, TId>)_commandRepositories[typeof(TEntity)];
        }
        /// <summary>
        /// Queries the repository.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <typeparam name="TId">The type of the identifier.</typeparam>
        /// <returns>
        /// IQueryRepository.
        /// </returns>
        public IQueryRepository<TEntity, TId> QueryRepository<TEntity, TId>() where TEntity : class, IEntityBase<TId>
        {
            if (!_queryRepositories.ContainsKey(typeof(TEntity)))
            {
                var repository = new QueryRepository<TEntity, TId>(_queryContext);
                _queryRepositories[typeof(TEntity)] = repository;
            }
            return (IQueryRepository<TEntity, TId>)_queryRepositories[typeof(TEntity)];
        }
        /// <summary>
        /// Saves the changes asynchronous.
        /// </summary>
        /// <returns>
        /// Task&lt;System.Int32&gt;.
        /// </returns>
        public async Task<int> SaveChangesAsync()
        {
            await _queryContext.SaveChangesAsync();
            return await _commandContext.SaveChangesAsync();
        }
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _queryContext.Dispose();
            _commandContext.Dispose();
        }
    }
}
