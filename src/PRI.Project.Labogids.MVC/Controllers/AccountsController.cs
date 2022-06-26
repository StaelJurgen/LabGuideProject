using Microsoft.AspNetCore.Mvc;

namespace PRI.Project.Labogids.MVC.Controllers
{
    public class AccountsController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
