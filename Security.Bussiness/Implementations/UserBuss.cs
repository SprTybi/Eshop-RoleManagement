using Security.BussinessServiceContract.Services;
using Security.DataAccessServiceContract.Repositories;
using Security.Domain.BaseModel;
using Security.Domain.DTO.Role;
using Security.Domain.DTO.User;
using Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Bussiness.Implementations
{
    public class UserBuss : IUserBuss
    {
        private readonly IUserRepository repo;
        public UserBuss(IUserRepository repo)
        {
            this.repo = repo;
        }

        public User GetUser(int userId)
        {
            return repo.Get(userId);
        }

        public OperationResult RegisterUser(UserAddModel user)
        {
            if (repo.ExistUserName(user.UserName))
            {
                return new OperationResult("RegisterUser", "User").ToFail("Register Failed");
            }
            return repo.Add(user);

        }

        public OperationResult RemoveUser(int userId)
        {
            return repo.Delete(userId);
        }

        public List<RoleDrp> RoleDrps()
        {
            return repo.RoleDrp();
        }

        public List<UserListItem> Search(UserSearchModel sm, out int RecordCount)
        {
            if (sm.PageSize == 0)
            {
                sm.PageSize = 20;
            }
            return repo.Search(sm, out RecordCount);
        }

        public OperationResult UpdateUser(UserUpdateModel user)
        {
            if (repo.ExistUserName(user.UserName))
            {
                return new OperationResult("UpdateUser", "User").ToFail("Update Failed");
            }
            return repo.Update(user);
        }
    }
}




