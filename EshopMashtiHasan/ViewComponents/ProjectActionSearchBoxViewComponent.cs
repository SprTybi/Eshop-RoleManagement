using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Security.BussinessServiceContract.Services;
using Security.Domain.DTO.ProjectAction;
using Security.Domain.DTO.ProjectController;
using Security.Domain.DTO.Role;
using Security.Domain.DTO.User;

namespace EshopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "ProjectActionSearchBox")]
    public class ProjectActionSearchBoxViewComponent : ViewComponent
    {
        private readonly IProjectActionBuss buss;
        public ProjectActionSearchBoxViewComponent(IProjectActionBuss buss)
        {
            this.buss = buss;
        }

        public void InflateDrpChoiseRole()
        {
            var controllerDrops = buss.ProjectControllerDrops();
            controllerDrops.Insert(0, new ProjectControllerDrop { ProjectControllerID = -1, ProjectControllerName = "..Controller.." });
            SelectList drpController = new SelectList(controllerDrops, "ProjectControllerID", "ProjectControllerName");
            ViewBag.drpController = drpController;
        }

        //public void InflateDrpChoiseProjectAction()
        //{
        //    var projectActions = buss.ProjectActionDrops();
        //    projectActions.Insert(0, new ProjectActionDrop { ProjectActionID = -1, ProjectActionName = "..Actions.." });
        //    SelectList drpProjectAction = new SelectList(projectActions, "projectActionsID", "projectActionsName");
        //    ViewBag.drpProjectAction = drpProjectAction;
        //}

        public IViewComponentResult Invoke()
        {
            //InflateDrpChoiseProjectAction();
            InflateDrpChoiseRole();
            return View();
        }
    }
}
