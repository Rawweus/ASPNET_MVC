using Microsoft.AspNetCore.Mvc;
using WebApp2.ViewModels;


namespace WebApp2.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}


/*
`HomeController` ansvarar för att hantera förfrågningar till applikationens startsida. 
När användare navigerar till roten av webbplatsen, hanterar `Index`-metoden 
dessa förfrågningar genom att returnera standardvyn för hemsidan. 
Det krävs ingen extra data eller komplex logik för att visa startsidan, 
så `Index`-metoden anropar `View()` direkt för att rendera vyn associerad med hemsidan.
*/
