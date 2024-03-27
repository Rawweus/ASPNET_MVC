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
		private readonly SignInManager<UserEntity> _signInManager; // Lägg till SignInManager

		// Uppdatera konstruktören för att inkludera SignInManager
		public AuthController(UserService userService, SignInManager<UserEntity> signInManager)
		{
			_userService = userService;
			_signInManager = signInManager; // Initiera _signInManager
		}

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
				var result = await _userService.CreateUserAsync(model);
				if (result.StatusCode == MyStatusCode.OK)
					return RedirectToAction("SignIn", "Auth");
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
				var result = await _userService.SignInUserAsync(model);
				if (result.StatusCode == MyStatusCode.OK)
					return RedirectToAction("Details", "Accounts");
			}

			ModelState.AddModelError(string.Empty, "Incorrect email or password.");
			return View(model);
		}

		[HttpPost]
		[Route("/signout")]
		public async Task<IActionResult> SignOut()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home"); // Eller vart du nu vill dirigera användaren efter utloggning
		}
	}
}



/*
`AccountController` hanterar användarregistrering och inloggning i din ASP.NET MVC-applikation.
Den använder `UserService` för att interagera med användarrelaterade tjänster.

- `SignUp() [HttpGet]`: Renderar en vy för användarregistrering. 
Den skapar och returnerar ett tomt `SignUpModel` till vyn.

- `SignUp(SignUpModel model) [HttpPost]`: Tar emot ett `SignUpModel` 
från registreringsformuläret. Om modellen är giltig, anropar den `CreateUserAsync` 
i `UserService` för att skapa en ny användare. Om användaren skapas framgångsrikt, 
omdirigeras användaren till inloggningssidan. Annars renderas registreringsvyn 
på nytt med den inmatade datan.

- `SignIn() [HttpGet]`: Renderar en vy för användarinloggning. Den skapar och returnerar 
ett tomt `SignInModel` till vyn.

- `SignIn(SignInModel model) [HttpPost]`: Tar emot ett `SignInModel` från 
inloggningsformuläret. Om modellen är giltig, försöker den logga in användaren 
genom att anropa `SignInUserAsync` i `UserService`. Vid framgångsrik inloggning 
omdirigeras användaren till en annan sida (i detta fall, "Details" i "Account"-kontrollern). 
Om inloggningen misslyckas på grund av felaktig e-post eller lösenord, 
renderas inloggningsvyn på nytt med ett felmeddelande.

Denna kontroller möjliggör enkel hantering av användarregistrering och 
inloggning, med tydlig separation av ansvarsområden mellan 
kontrollern och tjänstlagret.
*/
