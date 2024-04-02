using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Repositories;
using Infrastructure.Models;
using WebApp2.Models;
using WebApp2.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;

public class AccountsController : Controller
{
	private readonly UserManager<UserEntity> _userManager;
	private readonly UserRepository _userRepository;
	private readonly DataContext _context; // Din DataContext
    private readonly IHttpClientFactory _httpClientFactory;

    public AccountsController(UserManager<UserEntity> userManager, UserRepository userRepository, DataContext context)
	{
		_userManager = userManager;
		_userRepository = userRepository;
		_context = context;
	}

    public IActionResult RedirectToDetails()
    {
        return RedirectToAction("Details");
    }


    [HttpGet("/account")]
    public async Task<IActionResult> Details()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return RedirectToAction("SignIn", "Auth");
        }

        var userAddress = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == user.AddressId);
        var viewModel = new AccountDetailsViewModel
        {
            BasicInfo = new AccountDetailsBasicInfoModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
                Biography = user.Bio,
            },
            AddressInfo = userAddress != null ? new AccountDetailsAddressInfoModel
            {
                AddressLine_1 = userAddress.AddressLine1,
                AddressLine_2 = userAddress.AddressLine2,
                PostalCode = userAddress.PostalCode,
                City = userAddress.City,
            } : new AccountDetailsAddressInfoModel()
        };

        return View("Details", viewModel);
    }


    [HttpPost]
    [Route("/account")]
    public async Task<IActionResult> UpdateAccountDetails(AccountDetailsViewModel model)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return RedirectToAction("SignIn", "Auth");
        }

        if (ModelState.IsValid)
        {
            var result = await _userRepository.UpdateUserBasicInfo(user.Id, model.BasicInfo.Phone, model.BasicInfo.Biography);
            if (result.StatusCode == MyStatusCode.OK)
            {
                return RedirectToAction("Details", "Accounts");
            }

            ModelState.AddModelError("", result.Message);
        }

        // Återgå till /account-sidan om validering misslyckades
        return RedirectToAction("Details", "Accounts");
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

			var result = await _userRepository.UpdateUserBasicInfo(user.Id, model.BasicInfo.Phone, model.BasicInfo.Biography);
			if (result.StatusCode == MyStatusCode.OK)
			{
				return RedirectToAction("Details", "Accounts");
			}

			ModelState.AddModelError("", result.Message);
		}

		return View("Details", model);
	}

	[HttpPost]
	public async Task<IActionResult> AddressInfo(AccountDetailsViewModel model)
	{
		if (ModelState.IsValid)
		{
			var user = await _userManager.GetUserAsync(User);
			if (user == null)
			{
				return RedirectToAction("SignIn", "Auth");
			}

			AddressEntity address = null;

			if (user.AddressId.HasValue)
			{
				address = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == user.AddressId.Value);
			}

			if (address == null)
			{
				address = new AddressEntity();
				_context.Addresses.Add(address);
			}

			address.AddressLine1 = model.AddressInfo.AddressLine_1;
			address.AddressLine2 = model.AddressInfo.AddressLine_2;
			address.PostalCode = model.AddressInfo.PostalCode;
			address.City = model.AddressInfo.City;

			await _context.SaveChangesAsync();

			if (!user.AddressId.HasValue)
			{
				user.AddressId = address.Id;
				await _userManager.UpdateAsync(user);
			}

			return RedirectToAction("Details", "Accounts");
		}

		return RedirectToAction("Details", model);
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
