using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using WebApp2.Models;

namespace WebApp2.Controllers
{
    public class AccountController(UserService userService) : Controller
    {
        private readonly UserService _userService = userService;



		[HttpGet]
        [Route("/signup")]
		public IActionResult SignUp()
		{
			var model = new SignUpModel();
			return View(model);
		}

		[HttpPost]
		[Route("/signup")]
		public async Task<IActionResult> SignUp(SignUpModel model)
        {
            if (ModelState.IsValid)
            {
				var result = await _userService.CreateUserAsync(model); // Hans tog (viewModel.Form som jag inte har)
				if (result.StatusCode == Infrastructure.Models.StatusCode.OK)
					return RedirectToAction("SignIn", "Account");
			}
            return View(model);
        }

		[HttpGet]
		[Route("/signin")]
        public IActionResult SignIn()
        {
            var model = new SignInModel();
            return View(model);
        }



		[HttpPost]
		[Route("/signin")]
		public async Task<IActionResult> SignIn(SignInModel model)
		{
			if (ModelState.IsValid)
			{
				var result = await _userService.SignInUserAsync(model); // Använd direkt model eftersom du inte har viewModel.Form
				if (result.StatusCode == Infrastructure.Models.StatusCode.OK)
					return RedirectToAction("Details", "Account"); // Ändrat för att matcha din chefs beteende
			}

			ModelState.AddModelError(string.Empty, "Incorrect email or password.");
			return View(model);
		}

	}
}
