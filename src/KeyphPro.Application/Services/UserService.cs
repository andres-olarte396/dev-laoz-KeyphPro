using AutoMapper;
using KeyphPro.Application.Commond;
using KeyphPro.Domain.Entities.Commond;
using KeyphPro.Domain.Entities.Database;
using KeyphPro.Domain.Entities.Models;
using KeyphPro.Domain.Repositories;
using KeyphPro.Domain.Services;

namespace KeyphPro.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IBasicService<UserModel, User, Guid> _basicService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppLogger<BasicService<UserModel, User, Guid>> _logger;
        public UserService(IUnitOfWork unitOfWork,
            IMapper mapper,
            IAppLogger<BasicService<UserModel, User, Guid>> logger,
            IBasicService<UserModel, User, Guid> basicService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _basicService = basicService;
        }

        public Task<ResultModelBase<bool>> DeleteUser(UserModel user)
        {
            return _basicService.DeleteAsync(user.Id);
        }

        public Task<ResultModelBase<UserModel>> RegisterUser(UserModel user)
        {
            return _basicService.AddAsync(user);
        }

        public Task<ResultModelBase<bool>> EditUser(UserModel user)
        {
            return _basicService.UpdateAsync(user);
        }

        public ResultModelBase<bool> ValidateUserData(UserModel user)
        {
            var results = _basicService.Validate(user);
            if (results.Count != 0)
            {
                var msg = string.Join("\n - ", results);
                return new ResultModelBase<bool>(msg);
            }

            return new ResultModelBase<bool>(true, 200, "Success");
        }
    }
}
