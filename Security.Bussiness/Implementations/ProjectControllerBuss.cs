using Security.BussinessServiceContract.Services;
using Security.DataAccessServiceContract.Repositories;
using Security.Domain.BaseModel;
using Security.Domain.DTO.ProjectArea;
using Security.Domain.DTO.ProjectController;
using Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Bussiness.Implementations
{
    public class ProjectControllerBuss : IProjectControllerBuss
    {
        private readonly IProjectControllerRepository repo;
        public ProjectControllerBuss(IProjectControllerRepository repo)
        {
            this.repo = repo;
        }
        public OperationResult Delete(int ProjectControllerID)
        {
            return repo.Delete(ProjectControllerID);
        }

        public ProjectController GetProjectController(int ProjectControllerID)
        {
            return repo.Get(ProjectControllerID);
        }

        public List<ProjectAreaDrop> ProjectAreaDrps()
        {
            return repo.ProjectAreaDrps();
        }

        public OperationResult Register(ProjectControllerAddModel cont)
        {
            if (repo.ExitsProjectControllerName(cont.ProjectControllerName))
            {
                return new OperationResult("Register failed", "ProjectController").ToFail("ControllerName already exist!!");
            }
            return repo.Add(cont);
        }

        public List<ProjectControllerListItem> Search(ProjectControllerSearchModel sm, out int RecordCount)
        {
            if(sm.PageSize == 0)
            {
                sm.PageSize = 20;
            }
            return repo.Search(sm, out RecordCount);
        }

        public OperationResult update(ProjectControllerUpdateModel cont)
        {
            if (repo.ExitsProjectControllerName(cont.ProjectControllerName,cont.ProjectControllerID))
            {
                return new OperationResult("Update failed", "ProjectController").ToFail("ControllerName already exist!!");
            }
            return repo.Update(cont);
        }
    }
}
