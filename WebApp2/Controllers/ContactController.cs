using Microsoft.AspNetCore.Mvc;

namespace WebApp2.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Contact us";
            return View();
        }
    }
}
