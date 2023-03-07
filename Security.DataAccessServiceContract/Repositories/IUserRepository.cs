using Security.DataAccessServiceContract.Base;
using Security.Domain.DTO.User;
using Security.Domain.DTO.Role;
using Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.DataAccessServiceContract.Repositories
{
    public interface IUserRepository : IBaseRepositorySearchable<User, int, UserSearchModel, UserListItem, UserUpdateModel, UserAddModel>
    {
        bool ExistUserName(string userName);
        bool ExistUserName(string userName,int userId);
        List<RoleDrp> RoleDrp();
    }
}

