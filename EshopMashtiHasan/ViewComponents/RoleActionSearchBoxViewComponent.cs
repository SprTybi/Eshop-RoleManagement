using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Security.BussinessServiceContract.Services;
using Security.Domain.DTO.ProjectAction;
using Security.Domain.DTO.Role;
using Security.Domain.DTO.RoleAction;
using Security.Domain.DTO.User;

namespace EshopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "RoleActionSearchBox")]
    public class RoleActionSearchBoxViewComponent : ViewComponent
    {
        private readonly IRoleActionBuss buss;
        public RoleActionSearchBoxViewComponent(IRoleActionBuss buss)
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
            SelectList drpProjectAction = new SelectList(projectActions, "projectActionsID", "projectActionsName");
            ViewBag.drpProjectAction = drpProjectAction;
        }

        public IViewComponentResult Invoke(RoleActionSearchModel sm)
        {
            InflateDrpChoiseProjectAction();
            InflateDrpChoiseRole();
            return View(sm);
        }
    }
}
