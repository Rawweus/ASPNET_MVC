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


/*
`ContactController` hanterar kontaktrelaterade åtgärder inom din ASP.NET MVC-applikation. 
Den innehåller en metod för att visa kontaktformuläret eller 
kontaktinformationen till användarna.

- `Index()`: Den här metoden är ansvarig för att visa kontaktinformationen 
eller ett kontaktformulär till användaren. Den använder `ViewData`-dictionaryt 
för att skicka en titel till vyn, vilket indikerar att sidan är avsedd 
för att "Kontakta oss". Denna metod returnerar sedan standardvyn associerad 
med denna åtgärd, vilket ger användarna information eller ett formulär för att nå ut.

Denna kontroller är enkel och direkt, vilket visar hur `ViewData` kan användas 
för att skicka data från kontrollern till vyn för dynamisk webbsideinnehåll. 
Den är ett exempel på hur man strukturerar en kontroller för statiska sidor 
inom MVC-applikationer.
*/
