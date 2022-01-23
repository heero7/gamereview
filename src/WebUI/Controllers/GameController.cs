using Application.Games.Commands;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

[Route("api/[controller]")]
public class GameController : GameReviewBaseController
{
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateGameCommand command)
    {
        return await Mediator.Send(command);
    }
}