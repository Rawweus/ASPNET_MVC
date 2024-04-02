using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;
using WebApp2.ViewModels; // Antag att detta är korrekt plats för SubscriberViewModel

namespace WebApp2.Controllers;

public class SubscribersController : Controller
{
    private readonly IHttpClientFactory _clientFactory;

    public SubscribersController(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    [HttpPost]
    public async Task<IActionResult> Subscribe(SubscriberViewModel model)
    {
        if (ModelState.IsValid)
        {
            var client = _clientFactory.CreateClient();
            var subscriberJson = JsonSerializer.Serialize(new { Email = model.Email });
            var content = new StringContent(subscriberJson, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7234/api/subscribers", content);

            if (response.IsSuccessStatusCode)
            {
                ViewBag.SubscriptionSuccessMessage = "Tack för din prenumeration!";
            }
            else
            {
                // Hämtar responsens innehåll som en sträng
                var errorContent = await response.Content.ReadAsStringAsync();

                // Anpassar felmeddelandet baserat på statuskoden
                switch (response.StatusCode)
                {
                    case System.Net.HttpStatusCode.BadRequest:
                        ViewBag.SubscriptionErrorMessage = "Ogiltig förfrågan. Kontrollera inmatningsdatan.";
                        break;
                    case System.Net.HttpStatusCode.NotFound:
                        ViewBag.SubscriptionErrorMessage = "Resursen kunde inte hittas.";
                        break;
                    case System.Net.HttpStatusCode.InternalServerError:
                        ViewBag.SubscriptionErrorMessage = "Ett internt serverfel uppstod.";
                        break;
                    default:
                        ViewBag.SubscriptionErrorMessage = "Ett fel uppstod: " + errorContent;
                        break;
                }
                return View("~/Views/Home/Index.cshtml");
            }
        }

        // Här skapar du ett nytt tomt modellobjekt som ska användas om ModelState inte är giltig
        // eller om du vill återgå till formuläret utan att visa tidigare inmatade värden.
        var emptyModel = new SubscriberViewModel();
        return View("~/Views/Home/Index.cshtml", emptyModel);
    }


}
