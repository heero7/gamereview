using Application.Games.Commands;
using Application.Games.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

[Route("api/[controller]")]
public class GameController : GameReviewBaseController
{
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateGameCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpGet]
    public async Task<ActionResult<GameViewModel>> Get(GetGameByIdQuery query)
    {
        return Ok(await Mediator.Send(query));
    }

    [HttpGet]
    [Route("Category")]
    public async Task<ActionResult<GameViewModel>> GetByCategory(GetGamesByCategoryQuery query)
    {
        return Ok(await Mediator.Send(query));
    }
}