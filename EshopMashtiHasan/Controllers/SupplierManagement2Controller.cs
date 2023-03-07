using Microsoft.AspNetCore.Mvc;
using Shopping.DomainModel.DTO.Supplier;

namespace EshopMashtiHasan.Controllers
{
    public class SupplierManagement2Controller : Controller
    {
        public IActionResult Index(SupplierSearchModel sm)
        {
            return View(sm);
        }
    }
}
