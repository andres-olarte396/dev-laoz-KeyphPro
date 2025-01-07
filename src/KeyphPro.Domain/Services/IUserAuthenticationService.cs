using KeyphPro.Domain.Entities.Commond;
using KeyphPro.Domain.Entities.Models;

namespace KeyphPro.Domain.Services
{
    public interface IUserAuthenticationService
    {
        Task<ResultModelBase<TokenModel>> Login(LoginModel login);
        Task<ResultModelBase<bool>> Logout();
    }
}
