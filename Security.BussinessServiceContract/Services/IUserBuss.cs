using Security.Domain.BaseModel;
using Security.Domain.DTO.Role;
using Security.Domain.DTO.User;
using Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.BussinessServiceContract.Services
{
    public interface IUserBuss
    {
        OperationResult RegisterUser(UserAddModel user);
        OperationResult UpdateUser(UserUpdateModel user);
        OperationResult RemoveUser(int userId);
        List<UserListItem> Search(UserSearchModel sm, out int RecordCount);
        User GetUser(int userId);
        List<RoleDrp> RoleDrps();
    }
}
