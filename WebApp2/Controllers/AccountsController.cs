using Microsoft.AspNetCore.Mvc;
using WebApp2.Models;
using WebApp2.ViewModels;

namespace WebApp2.Controllers;

public class AccountsController : Controller
{
    //private readonly AccountService _accountService;

    //public AccountsController(AccountService accountService)
    //{
    //    _accountService = accountService;
    //}

    [Route("/account")]
	public IActionResult Details()
	{
		var viewModel = new AccountDetailsViewModel();
		//model.BasicInfo = _accountService.GetBasicInfo();
		//model.AddressInfo = _accountService.GetBasicInfo();
		return View(viewModel);
	}

	[HttpPost]
    public IActionResult BasicInfo(AccountDetailsBasicInfoModel model)
    { 
		//_accountService.SaveBasicInfo(model.BasicInfo);
        return RedirectToAction("Details");
    }

	[HttpPost]
	public IActionResult AddressInfo(AccountDetailsAddressInfoModel model)
	{
		//_accountService.SaveAddressInfo(model.AddressInfo);
		return RedirectToAction("Details");
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
