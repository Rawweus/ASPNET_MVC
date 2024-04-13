using Microsoft.AspNetCore.Mvc;
using WebApp2.ViewModels;


namespace WebApp2.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Error()
    {
        return View();
    }

}

