using Application.Genres.Commands;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

[Route("api/[controller]")]
public class GenreController : GameReviewBaseController
{
    [HttpPost]
    public async Task<ActionResult<int>> CreateGenre(CreateGenreCommand command)
    {
        return await Mediator.Send(command);
    }
}