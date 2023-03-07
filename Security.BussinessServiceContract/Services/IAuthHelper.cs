using Security.Domain.DTO.User;

namespace Security.BussinessServiceContract.Services
{
    public interface IAuthHelper
    {
        void Signin(UserInfo account);
        void Signout();
        UserInfo GetCurrentUserInfo();
    }
}