using KeyphPro.Domain.Entities.Database;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace KeyphPro.Domain.Entities.Commond
{
    /// <summary>
    /// Command Entity
    /// </summary>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    /// <seealso cref="KeyphPro.Domain.Entities.Commond.IEntityBase&lt;TId&gt;" />
    public class EntityBase<TId> : IEntityBase<TId>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityBase{TId}"/> class.
        /// </summary>
        public EntityBase() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityBase{TId}"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public EntityBase(TId id) { Id = id; }
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public TId Id { get; set; }
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        [JsonIgnore]
        public string? UserName { get; set; } = "Undefined";
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        [JsonIgnore]
        public DateTime Date { get; set; } = DateTime.Now;
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="EntityBase{TId}"/> is deleted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if deleted; otherwise, <c>false</c>.
        /// </value>
        [JsonIgnore]
        public bool Deleted { get; set; } = false;
        /// <summary>
        /// Gets or sets the type of the operation.
        /// </summary>
        /// <value>
        /// The type of the operation.
        /// </value>
        [JsonIgnore]
        public OperationType OperationType { get; set; } = OperationType.Create;
        public string User { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// Gets or sets the error.
        /// </summary>
        /// <value>
        /// The error.
        /// </value>
        [JsonIgnore]
        [IgnoreDataMember]
        private string Error;
        /// <summary>
        /// Gets the result data.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="model"></param>
        /// <returns>
        /// Result data
        /// </returns>
        public ResultModelBase<TModel> GetResult<TModel>(TModel model)
        {
            return new ResultModelBase<TModel>()
            {
                Result = model,
                Success = true,
                Message = this.Error ?? "Success"
            };
        }
        /// <summary>
        /// Gets the audit data.
        /// </summary>
        /// <returns>
        /// The audit data.
        /// </returns>
        public Audit GetAudit()
        {
            return new Audit()
            {
                User = this.User,
                Id = 0,
                IdAudit = this.Id?.ToString(),
                Entity = GetType().Name,
                OperationType = this.OperationType,
                Date = this.Date,
                Success = true,
                Deleted = this.Deleted
            };
        }
    }
}
