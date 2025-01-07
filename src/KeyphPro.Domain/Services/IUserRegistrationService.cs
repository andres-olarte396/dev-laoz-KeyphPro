using KeyphPro.Domain.Entities.Commond;
using KeyphPro.Domain.Entities.Models;

namespace KeyphPro.Domain.Services
{
    public interface IUserRegistrationService
    {
        Task<ResultModelBase<UserModel>> RegisterUser(UserModel user);
        Task<ResultModelBase<UserModel>> UpdateUser(UserModel user);
        Task<ResultModelBase<bool>> DeleteUser(UserModel user);
        Task<ResultModelBase<UserModel>> ValidateUserData(UserModel user);
    }
}
