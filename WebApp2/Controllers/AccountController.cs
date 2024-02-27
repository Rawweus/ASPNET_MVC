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

        [Route("/signup")]
		public IActionResult SignUp()
		{
			return View();
		}

		[Route("/signin")]
		public IActionResult SignIn()
        {
            ViewData["Title"] = "Sign in";
            return View();
        }

        public new IActionResult SignOut()
        {
            return View();
        }
    }
}
