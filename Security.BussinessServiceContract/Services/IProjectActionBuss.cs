using Security.Domain.BaseModel;
using Security.Domain.DTO.ProjectAction;
using Security.Domain.DTO.ProjectController;
using Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.BussinessServiceContract.Services
{
    public interface IProjectActionBuss
    {
        OperationResult Register(ProjectActionAddModel PA);
        OperationResult update(ProjectActionUpdateModel PA);
        OperationResult Delete(int ProjectActionID);
        List<ProjectActionListItem> Search(ProjectActionSearchModel sm, out int RecordCount);
        ProjectAction GetProjectAction(int ProjectActionID);
        List<ProjectControllerDrop> ProjectControllerDrops();
        int GetProjectController(string Controller);
        bool ExistProjectActionNameInController(int ControllerId,string ProjectActionName);
    }
}
