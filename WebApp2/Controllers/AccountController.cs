using Microsoft.AspNetCore.Mvc;

namespace WebApp2.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Profile";
            return View();
        }

        public IActionResult SignIn()
        {
            ViewData["Title"] = "Sign in";
            return View();
        }

        public IActionResult SignUp()
        {
            ViewData["Title"] = "Sign up";
            return View();
        }

        public new IActionResult SignOut()
        {
            return View();
        }
    }
}
