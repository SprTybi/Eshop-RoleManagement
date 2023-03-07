using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Security.BussinessServiceContract.Services;
using Security.Domain.DTO.Role;
using Security.Domain.DTO.User;

namespace EshopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "UserSearchBox")]
    public class UserSearchBoxViewComponent:ViewComponent
    {
        private readonly IUserBuss buss;
        public UserSearchBoxViewComponent(IUserBuss buss)
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

        public IViewComponentResult Invoke(UserSearchModel sm)
        {
            InflateDrpChoiseRole();
            return View(sm);
        }
    }
}
