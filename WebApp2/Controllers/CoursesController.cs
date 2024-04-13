using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApp2.ViewModels;

namespace WebApp2.Controllers;

using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp2.ViewModels;
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
            var response = await client.GetAsync("https://localhost:7234/api/courses");

            if (response.IsSuccessStatusCode)
            {
                var coursesString = await response.Content.ReadAsStringAsync();
                var courses = JsonSerializer.Deserialize<IEnumerable<CourseViewModel>>(coursesString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return View(courses);
            }
            else
            {

                var error = await response.Content.ReadAsStringAsync();
                ViewBag.ErrorMessage = $"API returned {response.StatusCode}: {error}";
                return View("Error");
            }
        }
        catch (HttpRequestException e)
        {

            ViewBag.ErrorMessage = $"Request failed: {e.Message}";
            return View("Error");
        }
        catch (Exception e)
        {

            ViewBag.ErrorMessage = $"An unexpected error occurred: {e.Message}";
            return View("Error");
        }
    }
}


