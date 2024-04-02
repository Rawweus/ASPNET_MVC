using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApp2.ViewModels;

namespace WebApp2.Controllers;

using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp2.ViewModels; // Antag att denna namnrymd innehåller CourseViewModel
using System;

public class CoursesController : Controller
{
    private readonly IHttpClientFactory _clientFactory;

    public CoursesController(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _clientFactory.CreateClient();
        try
        {
            var response = await client.GetAsync("https://localhost:7234/api/courses"); // Anpassa porten efter behov

            if (response.IsSuccessStatusCode)
            {
                var coursesString = await response.Content.ReadAsStringAsync();
                var courses = JsonSerializer.Deserialize<IEnumerable<CourseViewModel>>(coursesString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return View(courses);
            }
            else
            {
                // Om API:et svarar men inte med en framgångsstatuskod
                var error = await response.Content.ReadAsStringAsync();
                ViewBag.ErrorMessage = $"API returned {response.StatusCode}: {error}";
                return View("Error");
            }
        }
        catch (HttpRequestException e)
        {
            // Något gick fel vid försök att göra HTTP-anropet
            ViewBag.ErrorMessage = $"Request failed: {e.Message}";
            return View("Error");
        }
        catch (Exception e)
        {
            // Generellt undantagshantering
            ViewBag.ErrorMessage = $"An unexpected error occurred: {e.Message}";
            return View("Error");
        }
    }
}




// In WebApp2/Controllers

//public class CoursesController : Controller
//{
//    private readonly IHttpClientFactory _clientFactory;

//    public CoursesController(IHttpClientFactory clientFactory)
//    {
//        _clientFactory = clientFactory;
//    }

//    public async Task<IActionResult> Index()
//    {
//        var client = _clientFactory.CreateClient();
//        var response = await client.GetAsync("https://localhost:7234/api/courses"); // Anpassa porten efter behov

//        if (response.IsSuccessStatusCode)
//        {
//            var coursesString = await response.Content.ReadAsStringAsync();
//            var courses = JsonSerializer.Deserialize<IEnumerable<CourseViewModel>>(coursesString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
//            return View(courses);
//        }

//        return View("Error"); // Se till att ha en Error-vy för felhantering
//    }
//}

