using KeyphPro.Domain.Entities.Commond;
using System.ComponentModel.DataAnnotations;

namespace KeyphPro.Domain.Services
{
    /// <summary>
    /// Interface IDataService
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface IBasicService<TModel, TEntity, TId>
    {
        /// <summary>
        /// Gets the by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// TEntity
        /// </returns>
        Task<ResultModelBase<TModel?>> GetByIdAsync(TId id);
        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <returns>
        /// IEnumerable<TEntity>
        /// </returns>
        Task<ResultModelBase<IEnumerable<TModel>?>> GetAllAsync();
        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="entity">The model.</param>
        /// <returns>
        /// TId
        /// </returns>
        Task<ResultModelBase<TModel?>> AddAsync(TModel model);
        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="entity">The model.</param>
        /// <returns>
        /// bool
        /// </returns>
        Task<ResultModelBase<bool>> UpdateAsync(TModel model);
        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<ResultModelBase<bool>> DeleteAsync(TId id);
        /// <summary>
        /// Validates the specified model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>
        /// IList<ValidationResult>
        /// </returns>
        IList<ValidationResult> Validate(TModel model);
    }
}
