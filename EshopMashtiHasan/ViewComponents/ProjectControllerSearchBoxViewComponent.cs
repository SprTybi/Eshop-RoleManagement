using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Security.BussinessServiceContract.Services;
using Security.Domain.DTO.ProjectArea;
using Security.Domain.DTO.ProjectController;

namespace EshopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "ProjectControllerSearchBox")]
    public class ProjectControllerSearchBoxViewComponent : ViewComponent
    {
        private readonly IProjectControllerBuss buss;
        public ProjectControllerSearchBoxViewComponent(IProjectControllerBuss buss)
        {
            this.buss = buss;
        }

        //if have drop down in search and add
        //public void InflateDrpChoiseRole()
        //{
        //    var roles = buss.RoleDrps();
        //    roles.Insert(0, new RoleDrp { RoleID = -1, RoleName = "..Role.." });
        //    SelectList drpRole = new SelectList(roles, "RoleID", "RoleName");
        //    ViewBag.drpRole = drpRole;
        //}

        public void InflateDrpRegister()
        {
            var areaDrop = buss.ProjectAreaDrps();
            areaDrop.Insert(0, new ProjectAreaDrop { ProjectAreaID = -1, AreaName = "...Area..." });
            SelectList drpArea = new SelectList(areaDrop, "ProjectAreaID", "AreaName");
            ViewBag.drpArea = drpArea;
        }

        public IViewComponentResult Invoke(ProjectControllerSearchModel sm)
        {
            InflateDrpRegister();
            return View(sm);
        }
    }
}
