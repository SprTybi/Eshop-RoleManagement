using Security.BussinessServiceContract.Services;
using Security.DataAccessServiceContract.Repositories;
using Security.Domain.BaseModel;
using Security.Domain.DTO.ProjectAction;
using Security.Domain.DTO.Role;
using Security.Domain.DTO.RoleAction;
using Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Bussiness.Implementations
{
    public class RoleActionBuss : IRoleActionBuss
    {
        private readonly IRoleActionRepository repo;
        public RoleActionBuss(IRoleActionRepository repo)
        {
            this.repo = repo;
        }
        public OperationResult Remove(int RoleActionID)
        {
            return repo.Delete(RoleActionID);
        }

        public RoleAction GetRoleAction(int RoleActionID)
        {
            return repo.Get(RoleActionID);
        }

        public List<ProjectActionDrop> ProjectActionDrops()
        {
            return repo.ProjectActionDrops();
        }

        public OperationResult Register(RoleActionAddModel RoleAction)
        {
            return repo.Add(RoleAction);
        }

        public List<RoleDrp> RoleDrps()
        {
            return repo.RoleDrps();
        }

        public List<RoleActionListItem> Search(RoleActionSearchModel sm, out int RecordCount)
        {
            if (sm.PageSize == 0)
            {
                sm.PageSize = 20;
            }
            return repo.Search(sm, out RecordCount);
        }

        public OperationResult update(RoleActionUpdateModel RoleAction)
        {
            return repo.Update(RoleAction);
        }
    }
}
