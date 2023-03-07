using Security.Domain.BaseModel;
using Security.Domain.DTO.ProjectArea;
using Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.BussinessServiceContract.Services
{
    public interface IProjectAreaBuss
    {
        OperationResult Register(ProjectAreaAddModel Area);
        OperationResult update(ProjectAreaUpdateModel Area);
        OperationResult Delete(int ProjectAreaID);
        List<ProjectAreaListItem> Search(ProjectAreaSearchModel sm, out int RecordCount);
        ProjectArea GetProjectArea(int ProjectAreaID);
    }
}
