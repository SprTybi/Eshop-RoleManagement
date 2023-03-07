using Security.Domain.BaseModel;
using Security.Domain.DTO.ProjectArea;
using Security.Domain.DTO.ProjectController;
using Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.BussinessServiceContract.Services
{
    public interface IProjectControllerBuss
    {
        OperationResult Register(ProjectControllerAddModel cont);
        OperationResult update(ProjectControllerUpdateModel cont);
        OperationResult Delete(int ProjectControllerID);
        List<ProjectControllerListItem> Search(ProjectControllerSearchModel sm, out int RecordCount);
        ProjectController GetProjectController(int ProjectControllerID);
        List<ProjectAreaDrop> ProjectAreaDrps();
    }
}
