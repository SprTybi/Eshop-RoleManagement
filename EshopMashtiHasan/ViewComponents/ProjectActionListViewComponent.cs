using Microsoft.AspNetCore.Mvc;
using Security.BussinessServiceContract.Services;
using Security.Domain.DTO.ProjectAction;

namespace EshopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "ProjectActionList")]
    public class ProjectActionListViewComponent : ViewComponent
    {
        private readonly IProjectActionBuss buss;
        public ProjectActionListViewComponent(IProjectActionBuss buss)
        {
            this.buss = buss;
        }

        public IViewComponentResult Invoke(ProjectActionSearchModel sm)
        {
            if (sm.PageSize == 0 || sm == null)
            {
                sm.PageSize = 20;
            }
            int rc = 0;
            var ProjectActions = buss.Search(sm, out rc);
            return View(ProjectActions);
        }
    }
}
