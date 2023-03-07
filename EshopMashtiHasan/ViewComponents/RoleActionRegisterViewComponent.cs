using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Security.BussinessServiceContract.Services;
using Security.Domain.DTO.ProjectAction;
using Security.Domain.DTO.Role;
using Security.Domain.DTO.User;
using Shopping.DomainModel.DTO.Category;

namespace EshopMashtiHasan.ViewComponents
{
    [ViewComponent(Name ="RoleActionRegister")]
    public class RoleActionRegisterViewComponent : ViewComponent
    {
        private readonly IRoleActionBuss buss;
        public RoleActionRegisterViewComponent(IRoleActionBuss buss)
        {
            this.buss = buss;
        }
        public void InflateDrpChoiseRole()
        {
            var roles = buss.RoleDrps();
            roles.Insert(0, new RoleDrp { RoleID = -1, RoleName = "..Role.." });
            SelectList drpRole = new SelectList(roles, "RoleID", "RoleName");
            ViewBag.drpRole = drpRole;
        }

        public void InflateDrpChoiseProjectAction()
        {
            var projectActions = buss.ProjectActionDrops();
            projectActions.Insert(0, new ProjectActionDrop { ProjectActionID = -1, ProjectActionName = "..Actions.." });
            SelectList drpProjectAction = new SelectList(projectActions, "ProjectActionID", "ProjectActionName");
            ViewBag.drpProjectAction = drpProjectAction;
        }
        public IViewComponentResult Invoke()
        {
            InflateDrpChoiseProjectAction();
            InflateDrpChoiseRole();
            return View();
        }

    }
}
