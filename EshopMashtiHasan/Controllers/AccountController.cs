using Microsoft.AspNetCore.Mvc;
using Security.BussinessServiceContract.Services;
using Security.Domain.DTO.User;

namespace EshopMashtiHasan.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountBussiness buss;
        public AccountController(IAccountBussiness buss)
        {
            this.buss = buss;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Login l)
        {
            var op = buss.Login(l);
            return View();
        }


    }
}
