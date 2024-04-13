using Infrastructure.Entities;
using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp2.Models;

namespace WebApp2.Controllers
{
	public class AuthController : Controller
	{
		private readonly UserService _userService;
		private readonly SignInManager<UserEntity> _signInManager;

		public AuthController(UserService userService, SignInManager<UserEntity> signInManager)
		{
			_userService = userService;
			_signInManager = signInManager; 
		}

        [HttpGet]
        [Route("/signup")]
        public IActionResult SignUp()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("RedirectToDetails", "Accounts");
            }

            return View(new SignUpModel());
        }


        [HttpPost]
        [Route("/signup")]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Details", "Accounts");
            }

            if (ModelState.IsValid)
            {
                var result = await _userService.CreateUserAsync(model);
                if (result.StatusCode == MyStatusCode.OK)
                {
                    return RedirectToAction("SignIn", "Auth");
                }
            }
            return View(model);
        }


        [HttpGet]
        [Route("/signin")]
        public IActionResult SignIn()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("RedirectToDetails", "Accounts");
            }

            return View(new SignInModel());
        }




		[HttpPost]
		[Route("/signin")]
		public async Task<IActionResult> SignIn(SignInModel model)
		{
			if (ModelState.IsValid)
			{
				var result = await _userService.SignInUserAsync(model);
				if (result.StatusCode == MyStatusCode.OK)
                    return RedirectToAction("RedirectToDetails", "Accounts");
            }

			ModelState.AddModelError(string.Empty, "Incorrect email or password.");
			return View(model);
		}

		[HttpPost]
		[Route("/signout")]
		public new async Task<IActionResult> SignOut()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}
	}
}
