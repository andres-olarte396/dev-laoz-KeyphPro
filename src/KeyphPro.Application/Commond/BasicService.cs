    using AutoMapper;
using KeyphPro.Domain.Entities.Commond;
using KeyphPro.Domain.Entities.Database;
using KeyphPro.Domain.Repositories;
using KeyphPro.Domain.Services;
using System.ComponentModel.DataAnnotations;

namespace KeyphPro.Application.Commond
{
    public class BasicService<TModel, TEntity, TId> :
        IBasicService<TModel, TEntity, TId>
            where TEntity : class, IEntityBase<TId>
            where TModel : ModelBase<TId>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppLogger<BasicService<TModel, TEntity, TId>> _logger;

        public BasicService(IUnitOfWork unitOfWork, IMapper mapper, IAppLogger<BasicService<TModel, TEntity, TId>> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;

            _logger.LogInformation($"The BasicService for {typeof(TModel)} loaded...");
        }
        public async Task<ResultModelBase<TModel?>> AddAsync(TModel model)
        {
            try
            {
                var results = Validate(model);
                if (results.Count != 0)
                {
                    var msg = string.Join("\n - ", results);
                    return new ResultModelBase<TModel?>(msg);
                }

                var entity = _mapper.Map<TEntity>(model);
                entity.OperationType = OperationType.Create;
                entity.Date = DateTime.Now;
                entity.User = "System";
                entity.Id = await _unitOfWork.CommandRepository<TEntity, TId>().CreateAsync(entity);
                await _unitOfWork.SaveChangesAsync();

                model.Id = entity.Id;

                await _unitOfWork.CommandRepository<Audit, int>().CreateAsync(entity.GetAudit());
                await _unitOfWork.SaveChangesAsync();

                return new ResultModelBase<TModel?>(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {typeof(TModel)}", ex);
                return new ResultModelBase<TModel?>(ex.Message);
            }
        }
        public async Task<ResultModelBase<bool>> DeleteAsync(TId id)
        {
            var entity = await _unitOfWork.QueryRepository<TEntity, TId>().GetByIdAsync(id);

            if (entity == null)
                return new ResultModelBase<bool>($"Not found in {typeof(TEntity)}.");

            entity.OperationType = OperationType.Delete;
            entity.Date = DateTime.Now;
            entity.User = "System";
            entity.Deleted = true;

            try
            {
                bool result = await _unitOfWork.CommandRepository<TEntity, TId>().DeleteAsync(entity);
                await _unitOfWork.SaveChangesAsync();

                await _unitOfWork.CommandRepository<Audit, int>().CreateAsync(entity.GetAudit());
                await _unitOfWork.SaveChangesAsync();

                return new ResultModelBase<bool>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {typeof(TModel)}", ex);
                return new ResultModelBase<bool>(ex.Message);
            }
        }
        public async Task<ResultModelBase<bool>> UpdateAsync(TModel model)
        {
            var entity = _mapper.Map<TEntity>(model);
            entity.OperationType = OperationType.Update;
            entity.Date = DateTime.Now;
            entity.User = "System";

            try
            {
                var results = Validate(model);
                if (results.Count != 0)
                {
                    var msg = string.Join("\n - ", results);
                    return new ResultModelBase<bool>(msg);
                }

                var result = await _unitOfWork.CommandRepository<TEntity, TId>().UpdateAsync(entity);
                await _unitOfWork.SaveChangesAsync();

                await _unitOfWork.CommandRepository<Audit, int>().CreateAsync(entity.GetAudit());
                await _unitOfWork.SaveChangesAsync();

                return new ResultModelBase<bool>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {typeof(TModel)}", ex);
                return new ResultModelBase<bool>(ex.Message);
            }
        }
        public async Task<ResultModelBase<IEnumerable<TModel>?>> GetAllAsync()
        {
            return await Task.Run(async () =>
            {
                IEnumerable<TEntity> entities = await _unitOfWork.QueryRepository<TEntity, TId>().GetAllAsync();
                var result = _mapper.Map<IEnumerable<TModel>>(entities);
                return new ResultModelBase<IEnumerable<TModel>?>(result);
            });
        }
        /// <summary>
        /// Gets the by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// TEntity
        /// </returns>
        public async Task<ResultModelBase<TModel?>> GetByIdAsync(TId id)
        {
            return await Task.Run(async () =>
            {
                TEntity? entity = await _unitOfWork.QueryRepository<TEntity, TId>().GetByIdAsync(id);
                TModel? result = _mapper.Map<TModel?>(entity);
                return new ResultModelBase<TModel?>(result);
            });
        }
        /// <summary>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <!-- Badly formed XML comment ignored for member "M:KeyphPro.Core.Services.IDataService`3.Validate(`0)" -->
        public IList<ValidationResult> Validate(TModel model)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, validationContext, validationResults, true);
            return validationResults;
        }
    }
}
