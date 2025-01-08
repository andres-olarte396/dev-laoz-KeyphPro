using KeyphPro.Domain.Entities.Commond;
using KeyphPro.Domain.Entities.Models;

namespace KeyphPro.Domain.Services
{
    public interface IUserService
    {
        Task<ResultModelBase<UserModel>> RegisterUser(UserModel user);
        Task<ResultModelBase<bool>> EditUser(UserModel user);
        Task<ResultModelBase<bool>> DeleteUser(UserModel user);
        ResultModelBase<bool> ValidateUserData(UserModel user);
    }
}
