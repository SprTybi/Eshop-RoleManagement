using Security.DataAccessServiceContract.Base;
using Security.Domain.DTO.Role;
using Security.Domain.DTO.User;
using Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.DataAccessServiceContract.Repositories
{
    public interface IRoleRepository : IBaseRepositorySearchable<Role, int, RoleSearchModel, RoleListItem,RoleUpdateModel,RoleAddModel>
    {
        bool ExistsRoleName(string RoleName);
        bool ExistsRoleName(string RoleName , int RoleId);
        int GetUserCount(int RoleID);
        List<UserListItem>UserList(int RoleID);

    }
}
