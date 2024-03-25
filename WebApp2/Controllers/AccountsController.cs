using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp2.ViewModels; // Uppdatera med korrekt namespace för din ViewModel
using Infrastructure.Entities;
using WebApp2.Models;
using Infrastructure.Repositories; // Uppdatera med korrekt namespace för UserEntity
using Infrastructure.Models;

public class AccountsController(UserManager<UserEntity> userManager, UserRepository userRepository) : Controller
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly UserRepository _userRepository = userRepository;


    [Route("/account")]
    public async Task<IActionResult> Details()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return RedirectToAction("SignIn", "Auth"); // Eller hantera detta på annat sätt

        var viewModel = new AccountDetailsViewModel
        {
            BasicInfo = new AccountDetailsBasicInfoModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
            },
            // Antag att AddressInfo ska fyllas på liknande sätt
            AddressInfo = new AccountDetailsAddressInfoModel
            {
                // Fyll i med data från user om tillgängligt
                // Exempel:
                // Addressline_1 = user.Address?.Line1,
                // City = user.Address?.City,
                // PostalCode = user.Address?.PostalCode,
                // Lägg till fler fält här efter behov
            }
        };

        return View(viewModel);
    }

	[HttpPost]
	public async Task<IActionResult> BasicInfo(AccountDetailsViewModel model)
	{
		if (User?.Identity?.IsAuthenticated != true)
		{
			return RedirectToAction("SignIn", "Auth");
		}

		if (ModelState.IsValid)
		{
			var user = await _userManager.GetUserAsync(User);
			if (user == null)
			{
				return RedirectToAction("SignIn", "Auth");
			}

			// Anpassning här: model.BasicInfo.Phone och model.BasicInfo.Biography
			var result = await _userRepository.UpdateUserBasicInfo(user.Id, model.BasicInfo.Phone, model.BasicInfo.Biography);
			if (result.StatusCode == MyStatusCode.OK)
			{
				return RedirectToAction("Details");
			}

			ModelState.AddModelError("", result.Message);
		}

		// Ingen ändring behövs här, men se till att skicka tillbaka samma model till vyn om det finns valideringsfel
		// Du behöver inte skapa en ny AccountDetailsViewModel eftersom "model" redan är en AccountDetailsViewModel
		return View("Details", model);
	}


	[HttpPost]
    public IActionResult AddressInfo(AccountDetailsAddressInfoModel model)
    {
        if (ModelState.IsValid)
        {
            // Logik för att spara adressinformation här
            // Antagligen vill du spara denna information för den inloggade användaren

            return RedirectToAction("Details");
        }

        // Om modellen inte är giltig, returnera samma vy med modellen för att visa valideringsfel
        return View("Details", model); // Eller hantera detta annorlunda beroende på din logik
    }

}



/*
`AccountsController` är avsedd att hantera åtgärder relaterade till användarkonton, 
såsom att visa och uppdatera kontoinformation. Detta exempel visar grunden 
för kontrollern, inklusive metoder för att visa detaljer om ett konto 
samt hantera uppdateringar av grundläggande och adressinformation för ett konto.

- `Details()`: Denna metod är ansvarig för att hämta och visa detaljerad 
information om användarens konto. Den skapar och använder en `AccountDetailsViewModel` 
för att representera den data som ska visas. Denna metod skulle normalt 
anropa en service, t.ex. `_accountService`, för att hämta den faktiska 
informationen om användaren, men den delen är kommenterad i exemplet.

- `BasicInfo(AccountDetailsBasicInfoModel model) [HttpPost]`: Tar emot en modell 
med grundläggande information från ett formulär och uppdaterar användarens 
grundläggande information genom en service, t.ex. `_accountService`. 
Efter att ha sparat den nya informationen omdirigeras användaren tillbaka till detaljvyen.

- `AddressInfo(AccountDetailsAddressInfoModel model) [HttpPost]`: Liksom `BasicInfo`, 
tar denna metod emot adressinformation från ett formulär och uppdaterar 
användarens adressinformation. Efter uppdatering omdirigeras användaren 
tillbaka till detaljvyen.

Observera att även om serviceanropen (`_accountService`) är kommenterade i exemplet, 
är detta hur du skulle integrera din kontroller med affärslogiklagret för att 
hantera faktiska dataoperationer. Metoderna illustrerar ett typiskt flöde 
för att uppdatera användarinformation i en MVC-applikation.
*/
