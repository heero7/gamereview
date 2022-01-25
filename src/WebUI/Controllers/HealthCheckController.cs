using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;


[Route("api/[controller]")]
public class HealthCheckController : GameReviewBaseController
{
    [HttpGet]
    public string Index()
    {
        return "We're doing well!";
    }
}