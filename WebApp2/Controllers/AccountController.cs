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

            // Antag att efter en lyckad registrering vill du omdirigera användaren till inloggningssidan.
            return RedirectToAction("SignIn", "Account");
        }

        [Route("/signin")]
        [HttpGet]
        public IActionResult SignIn()
        {
            var model = new SignInModel();
            return View(model);
        }

        [Route("/signin")]
        [HttpPost]
        public IActionResult SignIn(SignInModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

         
            bool isValidUser = VerifyUserCredentials(model.Email, model.Password);
            if (!isValidUser)
            {
                ModelState.AddModelError(string.Empty, "Incorrect email or password.");
                return View(model);
            }
            return RedirectToAction("Account", "Index");
        }

        private bool VerifyUserCredentials(string email, string password)
        {
            return false; 
        }

    }
}
