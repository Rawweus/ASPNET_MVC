using Microsoft.AspNetCore.Mvc;
using WebApp2.Models;

namespace WebApp2.Controllers
{
    public class AccountController : Controller
    {

        [Route("/signup")]
        [HttpGet]
		public IActionResult SignUp()
		{
            var model = new SignUpModel();
            return View(model);
		}


        [Route("/signup")]
        [HttpPost]
        public IActionResult SignUp(SignUpModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("SignIn", "Account");
        }

    }
}
