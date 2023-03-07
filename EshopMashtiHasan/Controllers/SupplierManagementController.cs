using Microsoft.AspNetCore.Mvc;
using Shopping.BussinessServiceContract.BussinessModel.Supplier;
using Shopping.BussinessServiceContract.Services;
using Shopping.DomainModel.DTO.Supplier;

namespace EshopMashtiHasan.Controllers
{
    public class SupplierManagementController : Controller
    {
        private readonly ISupplierBuss buss;

        public SupplierManagementController(ISupplierBuss repo)
        {
            this.buss = repo;
        }
        public IActionResult Index()
        {
            int rc = 0;
            var sups = buss.Search(new SupplierSearchModel {PageSize = 20}, out rc);
            return View(sups);
        }

        public IActionResult AddNew()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddNew(SupplierAddEditViewModel sup)
        {
            
            if (!ModelState.IsValid) 
            {
                return View(sup);
            }
            var op = buss.RegisterSupplier(sup);
            if (!op.Success)
            {
                TempData["ErrorMessage"] = op.Message;
                //ModelState.AddModelError("1","gvajvdfjgqvfhjavsd");
                return View(sup);
            }

            return RedirectToAction("Index", "SupplierManagement");
        }
    }
}
