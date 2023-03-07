using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Security.BussinessServiceContract.Services;
using Security.Domain.DTO.ProjectArea;
using Security.Domain.DTO.ProjectController;

namespace EshopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "ProjectAreaSearchBox")]
    public class ProjectAreaSearchBoxViewComponent : ViewComponent
    {
        private readonly IProjectAreaBuss buss;
        public ProjectAreaSearchBoxViewComponent(IProjectAreaBuss buss)
        {
            this.buss = buss;
        }

        public IViewComponentResult Invoke(ProjectAreaSearchModel sm)
        {
            return View(sm);
        }
    }
}
