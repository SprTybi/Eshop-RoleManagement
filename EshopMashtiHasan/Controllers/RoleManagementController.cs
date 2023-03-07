using DomainModel.BaseModel;
using Microsoft.AspNetCore.Mvc;
using Security.BussinessServiceContract.Services;
using Security.Domain.DTO.Role;
using Security.Domain.Models;
using Shopping.BussinessServiceContract.BussinessModel.Supplier;

namespace EshopMashtiHasan.Controllers
{
    public class RoleManagementController : Controller
    {
        private readonly IRoleBuss buss;
        public RoleManagementController(IRoleBuss buss)
        {
            this.buss = buss;
        }

        public IActionResult Index(RoleSearchModel sm)
        {
            return View(sm);
        }

        //show modal
        public IActionResult AddNew()
        {
            return ViewComponent("RoleRegister");
        }
        //add Role to db
        [HttpPost]
        public JsonResult AddNewRole(RoleAddModel Role)
        {
            var op = buss.RegisterRole(Role);
            return Json(op);
        }

        public IActionResult RoleList(RoleSearchModel sm)
        {
            return ViewComponent("RoleList", sm);
        }

        public IActionResult RoleSearchBox(RoleSearchModel sm)
        {
            return ViewComponent("RoleSearchBox", sm);
        }
        public JsonResult DeleteRole(int id)
        {
            var op = buss.RemoveRole(id);
            return Json(op);
        }

    }
}
