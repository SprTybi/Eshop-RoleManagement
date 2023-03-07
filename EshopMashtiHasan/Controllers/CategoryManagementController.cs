using DomainModel.BaseModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shopping.BussinessServiceContract.Services;
using Shopping.DomainModel.DTO.Category;

namespace EshopMashtiHasan.Controllers
{
    public class CategoryManagementController : Controller
    {
        private readonly ICategoryBuss catBuss;
       
        public CategoryManagementController(ICategoryBuss catBuss)
        {
            this.catBuss = catBuss;
        }
        
        //show modal
        public IActionResult AddNew()
        {
            return ViewComponent("RegisterCategory");
        }
        [HttpPost]
        public JsonResult AddNew(CategoryAddModel cat)
        {
            var op = catBuss.RegisterCategory(cat);
            return Json(op);
        }
        public IActionResult Index(CategorySearchModel sm)
        {
           
            return View(sm);
        }
        public IActionResult CategorySearchBoxAction(CategorySearchModel sm)
        {

            return ViewComponent("CategorySearchBox", sm);
        }
        public IActionResult CategoryListAction(CategorySearchModel sm)
        {
            return ViewComponent("CategoryList", sm);
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
           var op= catBuss.RemoveCategory(id);
            return Json(op);
        }
        
    }
}
