using MediatR;
using Microsoft.AspNetCore.Mvc;
using PVS.Application.Requests.Genre;
using PVS.Application.Responses.Genre;

namespace PVS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController(IMediator mediator) : Controller
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<GetGenreResponse> genres = await _mediator.Send(new GetGenresRequest());
            return Ok(genres);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            GetGenreResponse genre = await _mediator.Send(new GetGenreRequest(id));
            return Ok(genre);
        }
    }
}
