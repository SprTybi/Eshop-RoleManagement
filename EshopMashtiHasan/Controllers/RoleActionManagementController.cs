using Microsoft.AspNetCore.Mvc;
using Security.BussinessServiceContract.Services;
using Security.Domain.DTO.RoleAction;

namespace EshopMashtiHasan.Controllers
{
    public class RoleActionManagementController : Controller
    {
        private readonly IRoleActionBuss buss;
        public RoleActionManagementController(IRoleActionBuss buss)
        {
            this.buss = buss;
        }

        public IActionResult Index(RoleActionSearchModel sm)
        {
            return View(sm);
        }

        //show modal
        public IActionResult AddNew()
        {
            return ViewComponent("RoleActionRegister");
        }
        //add RoleAction to db
        [HttpPost]
        public JsonResult AddNewRoleAction(RoleActionAddModel ra)
        {
            var op = buss.Register(ra);
            return Json(op);
        }

        public IActionResult RoleActionList(RoleActionSearchModel sm)
        {
            return ViewComponent("RoleActionList", sm);
        }

        public IActionResult RoleActionSearchBox(RoleActionSearchModel sm)
        {
            return ViewComponent("RoleActionSearchBox", sm);
        }
        public JsonResult DeleteRoleAction(int id)
        {
            var op = buss.Remove(id);
            return Json(op);
        }

    }
}
