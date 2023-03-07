using Microsoft.AspNetCore.Mvc;
using Security.BussinessServiceContract.Services;
using Security.Domain.DTO.ProjectController;

namespace EshopMashtiHasan.Controllers
{
    public class ProjectControllerManagementController : Controller
    {
        private readonly IProjectControllerBuss buss;

        public ProjectControllerManagementController(IProjectControllerBuss buss) => this.buss = buss;

        public IActionResult Index(ProjectControllerSearchModel sm) => (View(sm));

        public IActionResult Add() => (ViewComponent("ProjectControllerRegister"));

        public JsonResult AddNewController(ProjectControllerAddModel model) => (Json(buss.Register(model)));

        public IActionResult ProjectControllerList(ProjectControllerSearchModel sm) => (ViewComponent("ProjectControllerList", sm));

        public IActionResult ProjectControllerSearch(ProjectControllerSearchModel sm) => (ViewComponent("ProjectControllerSearchBox", sm));

        public JsonResult Delete(int controllerId) => (Json(buss.Delete(controllerId)));

    }
}
