using Microsoft.AspNetCore.Mvc;
using Security.BussinessServiceContract.Services;
using Security.Domain.DTO.RoleAction;

namespace EshopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "RoleActionList")]
    public class RoleActionListViewComponent : ViewComponent
    {
        private readonly IRoleActionBuss buss;
        public RoleActionListViewComponent(IRoleActionBuss buss)
        {
            this.buss = buss;
        }

        public IViewComponentResult Invoke(RoleActionSearchModel sm)
        {
            if (sm.PageSize == 0 || sm == null)
            {
                sm.PageSize = 20;
            }
            int rc = 0;
            var RoleActions = buss.Search(sm, out rc);
            return View(RoleActions);
        }
    }
}
