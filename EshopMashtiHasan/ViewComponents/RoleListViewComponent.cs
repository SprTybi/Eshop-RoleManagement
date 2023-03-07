using Microsoft.AspNetCore.Mvc;
using Security.BussinessServiceContract.Services;
using Security.Domain.DTO.Role;

namespace EshopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "RoleList")]
    public class RoleListViewComponent : ViewComponent
    {
        private readonly IRoleBuss buss;
        public RoleListViewComponent(IRoleBuss buss)
        {
            this.buss = buss;
        }

        public IViewComponentResult Invoke(RoleSearchModel sm)
        {
            if (sm.PageSize == 0 || sm == null)
            {
                sm.PageSize = 20;
            }
            int rc = 0;
            var Roles = buss.Search(sm, out rc);
            return View(Roles);
        }
    }
}
