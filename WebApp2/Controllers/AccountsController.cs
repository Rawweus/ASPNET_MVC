using Microsoft.AspNetCore.Mvc;
using WebApp2.Models;

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
		var model = new AccountDetailsBasicInfoModel();
		//model.BasicInfo = _accountService.GetBasicInfo();
		//model.AddressInfo = _accountService.GetBasicInfo();
		return View(model);
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
