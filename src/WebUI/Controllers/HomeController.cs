using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}