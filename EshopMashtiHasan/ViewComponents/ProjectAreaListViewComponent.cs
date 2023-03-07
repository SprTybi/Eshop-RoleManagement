using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Security.BussinessServiceContract.Services;
using Security.Domain.DTO.ProjectArea;
using Security.Domain.DTO.ProjectController;
using Security.Domain.DTO.Role;
using Security.Domain.DTO.User;

namespace EshopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "ProjectAreaList")]
    public class ProjectAreaListViewComponent : ViewComponent
    {
        private readonly IProjectAreaBuss buss;
        public ProjectAreaListViewComponent(IProjectAreaBuss buss) => this.buss = buss;

        public IViewComponentResult Invoke(ProjectAreaSearchModel sm)
        {
            if (sm.PageSize == 0 || sm == null)
            {
                sm.PageSize = 20;
            }
            int rc = 0;
            var result = buss.Search(sm, out rc);
            return View(result);
        }
    }
}
