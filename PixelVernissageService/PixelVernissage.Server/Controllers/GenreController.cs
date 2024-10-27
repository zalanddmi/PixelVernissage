using MediatR;
using Microsoft.AspNetCore.Mvc;
using PVS.Application.Requests.Genre;

namespace PVS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : Controller
    {
        private readonly IMediator _mediator;

        public GenreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var genre = await _mediator.Send(new GetGenreRequest(id));
            return Ok(genre);
        }
    }
}
