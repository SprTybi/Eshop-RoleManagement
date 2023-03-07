using Security.DataAccessServiceContract.Base;
using Security.Domain.DTO.ProjectArea;
using Security.Domain.DTO.Role;
using Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.DataAccessServiceContract.Repositories
{
    public interface IProjectAreaRepository : IBaseRepositorySearchable<ProjectArea, int, ProjectAreaSearchModel, ProjectAreaListItem, ProjectAreaUpdateModel, ProjectAreaAddModel>
    {
        bool ExistAreaName(string AreaName);
        bool ExistAreaName(string AreaName, int AreaId);
    }
}
