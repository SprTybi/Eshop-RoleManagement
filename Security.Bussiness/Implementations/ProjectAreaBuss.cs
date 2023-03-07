using Security.BussinessServiceContract.Services;
using Security.DataAccessServiceContract.Repositories;
using Security.Domain.BaseModel;
using Security.Domain.DTO.ProjectArea;
using Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Bussiness.Implementations
{
    public class ProjectAreaBuss : IProjectAreaBuss
    {
        private readonly IProjectAreaRepository repo;
        public ProjectAreaBuss(IProjectAreaRepository repo)
        {
            this.repo = repo;
        }
        public OperationResult Delete(int ProjectAreaID)
        {
            return repo.Delete(ProjectAreaID);
        }

        public ProjectArea GetProjectArea(int ProjectAreaID)
        {
            return repo.Get(ProjectAreaID);
        }

        public OperationResult Register(ProjectAreaAddModel Area)
        {
            if (repo.ExistAreaName(Area.AreaName))
            {
                return new OperationResult("Register failed", "ProjectArea").ToFail("AreaName Already exist!!");
            }
            return repo.Add(Area);
        }

        public List<ProjectAreaListItem> Search(ProjectAreaSearchModel sm, out int RecordCount)
        {
            if (sm.PageSize == 0)
            {
                sm.PageSize = 20;
            }
            return repo.Search(sm, out RecordCount);
        }

        public OperationResult update(ProjectAreaUpdateModel Area)
        {
            if (repo.ExistAreaName(Area.AreaName, Area.ProjectAreaID))
            {
                return new OperationResult("Update failed", "ProjectArea").ToFail("AreaName already exist!!");
            }
            return repo.Update(Area);
        }
    }
}
