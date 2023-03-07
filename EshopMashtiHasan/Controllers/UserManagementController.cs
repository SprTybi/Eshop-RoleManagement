using DomainModel.BaseModel;
using Microsoft.AspNetCore.Mvc;
using Security.BussinessServiceContract.Services;
using Security.Domain.DTO.User;
using Security.Domain.Models;
using Shopping.BussinessServiceContract.BussinessModel.Supplier;

namespace EshopMashtiHasan.Controllers
{
    public class UserManagementController : Controller
    {
        private readonly IUserBuss buss;
        public UserManagementController(IUserBuss buss)
        {
            this.buss = buss;
        }

        public IActionResult Index(UserSearchModel sm)
        {
            return View(sm);
        }

        //show modal
        public IActionResult AddNew()
        {
            return ViewComponent("UserRegister");
        }
        //add user to db
        [HttpPost]
        public JsonResult AddNewUser(UserAddModel user)
        {
            var op = buss.RegisterUser(user);
            return Json(op);
        }

        public IActionResult UserList(UserSearchModel sm)
        {
            return ViewComponent("UserList", sm);
        }

        public IActionResult UserSearchBox(UserSearchModel sm)
        {
            return ViewComponent("UserSearchBox", sm);
        }
        public JsonResult DeleteUser(int id)
        {
            var op = buss.RemoveUser(id);
            return Json(op);
        }

    }
}
