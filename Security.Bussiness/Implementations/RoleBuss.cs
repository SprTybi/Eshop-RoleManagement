using Security.BussinessServiceContract.Services;
using Security.DataAccessServiceContract.Repositories;
using Security.Domain.BaseModel;
using Security.Domain.DTO.Role;
using Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Bussiness.Implementations
{
    public class RoleBuss : IRoleBuss
    {
        private readonly IRoleRepository repo;
        public RoleBuss(IRoleRepository repo)
        {
            this.repo = repo;
        }
        public Role GetRole(int Roleid)
        {
            return repo.Get(Roleid);
        }

        public OperationResult RegisterRole(RoleAddModel role)
        {
            if (repo.ExistsRoleName(role.RoleName))
            {
                return new OperationResult("Register User", "User").ToFail("Username already exist!!");
            }
            return repo.Add(role);
        }

        public OperationResult RemoveRole(int userId)
        {
            return repo.Delete(userId);
        }

        public List<RoleListItem> Search(RoleSearchModel sm, out int RecordCount)
        {
            if (sm.PageSize == 0)
            {
                sm.PageSize = 20;
            }
            return repo.Search(sm, out RecordCount);
        }

        public OperationResult UpdateRole(RoleUpdateModel role)
        {
            if (repo.ExistsRoleName(role.RoleName, role.RoleID))
            {
                return new OperationResult("Update Role", "Role").ToFail("Update fialed because role name already exist!!");
            }
            return repo.Update(role);
        }
    }
}
