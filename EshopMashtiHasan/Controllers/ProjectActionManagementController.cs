using Microsoft.AspNetCore.Mvc;
using Security.BussinessServiceContract.Services;
using Security.Domain.DTO.ProjectAction;

namespace EshopMashtiHasan.Controllers
{
    public class ProjectActionManagementController : Controller
    {
        private readonly IProjectActionBuss buss;
        public ProjectActionManagementController(IProjectActionBuss buss)
        {
            this.buss = buss;
        }

        public IActionResult Index(ProjectActionSearchModel sm)
        {
            return View(sm);
        }

        //show modal
        public IActionResult AddNew()
        {
            return ViewComponent("ProjectActionRegister");
        }
        //add ProjectAction to db
        [HttpPost]
        public JsonResult AddNewProjectAction(ProjectActionAddModel ra)
        {
            var op = buss.Register(ra);
            return Json(op);
        }

        public IActionResult ProjectActionList(ProjectActionSearchModel sm)
        {
            return ViewComponent("ProjectActionList", sm);
        }

        public IActionResult ProjectActionSearchBox(ProjectActionSearchModel sm)
        {
            return ViewComponent("ProjectActionSearchBox", sm);
        }
        public JsonResult DeleteProjectAction(int id)
        {
            var op = buss.Delete(id);
            return Json(op);
        }

    }
}
