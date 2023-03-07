using Microsoft.AspNetCore.Mvc;
using Security.BussinessServiceContract.Services;
using Security.Domain.DTO.ProjectArea;

namespace EshopMashtiHasan.Controllers
{
    public class ProjectAreaManagementController : Controller
    {
        private readonly IProjectAreaBuss buss;

        public ProjectAreaManagementController(IProjectAreaBuss buss) => this.buss = buss;

        public IActionResult Index(ProjectAreaSearchModel sm) => (View(sm));

        public IActionResult AddNew() => (ViewComponent("ProjectAreaRegister"));

        public JsonResult AddNewArea(ProjectAreaAddModel model) => (Json(buss.Register(model)));

        public IActionResult ProjectAreaList(ProjectAreaSearchModel sm) => (ViewComponent("ProjectAreaList", sm));

        public IActionResult ProjectAreaSearch(ProjectAreaSearchModel sm) => (ViewComponent("ProjectAreaSearch", sm));

        public JsonResult Delete(int areaId) => (Json(buss.Delete(areaId)));

    }
}
