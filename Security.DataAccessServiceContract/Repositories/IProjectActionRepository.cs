using Security.DataAccessServiceContract.Base;
using Security.Domain.DTO.ProjectAction;
using Security.Domain.DTO.ProjectController;
using Security.Domain.DTO.Role;
using Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.DataAccessServiceContract.Repositories
{
    public interface IProjectActionRepository : IBaseRepositorySearchable<ProjectAction, int, ProjectActionSearchModel, ProjectActionListItem,ProjectActionUpdateModel,ProjectActionAddModel>
    {
        bool ExistProjectActionName(string ProjectActionName);
        bool ExistProjectActionName(string ProjectActionName,int ProjectActionId);
        int GetProjectControllerId(string controller);
        bool ExistController(int ControllerId);
        public List<ProjectControllerDrop> PcDrops();
        bool ExistProjectActionNameInController(int ControllerId, string ProjectActionName);
        string GetProjectControllerById(int controllerId);
    }
}
