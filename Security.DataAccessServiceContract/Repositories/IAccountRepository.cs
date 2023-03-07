using Security.Domain.Models;
using Security.Domain.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Security.Domain.BaseModel;

namespace Security.DataAccessServiceContract.Repositories
{
    public interface IAccountRepository
    {
        public UserInfo GetUserInf(string Username);
        public OperationResult RegisterNewUser(User u);
        public User GetFullInfo(string Username);
        bool checkIfUserHasAccess(CheckPermission permission);
    }
}

