using KeyphPro.Domain.Entities.Database;
using System.Text.Json.Serialization;

namespace KeyphPro.Domain.Entities.Commond
{
    /// <summary>
    /// Command entity
    /// </summary>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface IEntityBase<TId>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        TId Id { get; set; }
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        [JsonIgnore]
        string Username { get; set; }
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        [JsonIgnore]
        DateTime Date { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IEntityBase{TId}"/> is deleted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if deleted; otherwise, <c>false</c>.
        /// </value>
        [JsonIgnore]
        bool Deleted { get; set; }
        /// <summary>
        /// Gets or sets the type of the operation.
        /// </summary>
        /// <value>
        /// The type of the operation.
        /// </value>
        [JsonIgnore]
        OperationType OperationType { get; set; }
        /// <summary>
        /// Gets the result data.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <returns>
        /// Result data
        /// </returns>
        ResultModelBase<TModel> GetResult<TModel>(TModel model);
        Audit GetAudit();
    }
    /// <summary>
    /// Operation type
    /// </summary>
    public enum OperationType
    {
        Create = 1,
        Repalce = 2,
        Update = 3,
        Delete = 4
    }
}