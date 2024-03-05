using Microsoft.AspNetCore.Mvc;

namespace WebApp2.Controllers
{
    public class DownloadsController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Downloads";
            return View();
        }
    }
}

/*
`DownloadsController` visar en sida för nedladdningar. 
Sätter titeln "Downloads" med `ViewData` och returnerar vyn.
*/
