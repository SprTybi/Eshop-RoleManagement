using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Security.BussinessServiceContract.Services;
using Security.Domain.DTO.Role;
using Security.Domain.DTO.User;

namespace EshopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "RoleSearchBox")]
    public class RoleSearchBoxViewComponent : ViewComponent
    {
        private readonly IRoleBuss buss;
        public RoleSearchBoxViewComponent(IRoleBuss buss)
        {
            this.buss = buss;
        }

        //public void InflateDrpChoiseRole()
        //{
        //    var roles = buss.RoleDrps();
        //    roles.Insert(0, new RoleDrp { RoleID = -1, RoleName = "..Role.." });
        //    SelectList drpRole = new SelectList(roles, "RoleID", "RoleName");
        //    ViewBag.drpRole = drpRole;
        //}

        public IViewComponentResult Invoke(RoleSearchModel sm)
        {
            //InflateDrpChoiseRole();
            return View(sm);
        }
    }
}
