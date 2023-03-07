using Security.Domain.BaseModel;
using Security.Domain.DTO.Role;
using Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.BussinessServiceContract.Services
{
    public interface IRoleBuss
    {
        OperationResult RegisterRole(RoleAddModel role);
        OperationResult UpdateRole(RoleUpdateModel role);
        OperationResult RemoveRole(int roleId);
        List<RoleListItem> Search(RoleSearchModel sm, out int RecordCount);
        Role GetRole(int Roleid);
    }
}
