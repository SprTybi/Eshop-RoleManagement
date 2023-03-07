using Security.DataAccessServiceContract.Base;
using Security.Domain.DTO.ProjectAction;
using Security.Domain.DTO.Role;
using Security.Domain.DTO.RoleAction;
using Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.DataAccessServiceContract.Repositories
{
    public interface IRoleActionRepository : IBaseRepositorySearchable<RoleAction, int, RoleActionSearchModel, RoleActionListItem,RoleActionUpdateModel, RoleActionAddModel>
    {
        public List<RoleDrp> RoleDrps();
        public List<ProjectActionDrop> ProjectActionDrops();
    }
}
