//installing package Microsoft.AspNetCore.Authentication

using Framework.Services;
using Security.BussinessServiceContract.Services;
using Security.DataAccessServiceContract.Repositories;
using Security.Domain.BaseModel;
using Security.Domain.DTO.User;
using Security.Domain.Models;

namespace Security.Bussiness.Implementations
{
    public class AccountBussiness : IAccountBussiness
    {
        private readonly IAuthHelper _authHelper;
        private readonly IAccountRepository _accountRepository;
        private readonly IPasswordHasher _passwordHasher;


        public AccountBussiness(IAccountRepository accountRepository, IAuthHelper authHelper, IPasswordHasher passwordHasher)
        {
            _accountRepository = accountRepository;
            _authHelper = authHelper;
            _passwordHasher = passwordHasher;
        }

        public OperationResult Login(Login login)
        {
            var result = new OperationResult("Login","User");
            var u = _accountRepository.GetFullInfo(login.Username);
            if (u == null)
            {
                return result.ToFail("شما هنوز ثبت نام نکرده اید");
            }

            var (verified, needsUpgrade) = _passwordHasher.Check(u.Password, login.Password);
            if (!verified)
            {
                return result.ToFail("Invalid Credential");
            }

            var userInfo = _accountRepository.GetUserInf(login.Username);


            _authHelper.Signin(userInfo);


            return result.ToSuccess(userInfo.UserID,"Login Successfully");
        }

        public OperationResult Register(User command)
        {
            return _accountRepository.RegisterNewUser(command);
        }

        public void LogoutUser()
        {
            _authHelper.Signout();
        }


        
        public UserInfo GetAccountInfo()
        {
            return _authHelper.GetCurrentUserInfo();
        }

        public bool CheckIfUserHasaccess(CheckPermission per)
        {
            return _accountRepository.checkIfUserHasAccess(per);
        }


    }
}