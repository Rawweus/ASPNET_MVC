using Microsoft.AspNetCore.Mvc;


namespace WebApp2.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
