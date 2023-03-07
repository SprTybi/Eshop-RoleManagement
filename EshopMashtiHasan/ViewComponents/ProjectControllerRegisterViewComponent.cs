using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Security.BussinessServiceContract.Services;
using Security.Domain.DTO.ProjectArea;

namespace EshopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "ProjectControllerRegister")]
    public class ProjectControllerRegisterViewComponent : ViewComponent
    {
        private readonly IProjectControllerBuss buss;
        public ProjectControllerRegisterViewComponent(IProjectControllerBuss buss)
        {
            this.buss = buss;
        }

        public void InflateDrpRegister()
        {
            var areaDrop = buss.ProjectAreaDrps();
            areaDrop.Insert(0, new ProjectAreaDrop { ProjectAreaID = -1, AreaName = "...Area..." });
            SelectList drpArea = new SelectList(areaDrop, "ProjectAreaID", "AreaName");
            ViewBag.drpArea = drpArea;
        }

        public IViewComponentResult Invoke()
        {
            InflateDrpRegister();
            return View();
        }

    }
}
