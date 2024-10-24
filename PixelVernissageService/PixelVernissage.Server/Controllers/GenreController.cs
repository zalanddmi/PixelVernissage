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

        [HttpPost]
        public async Task<IActionResult> Get(GetGenreRequest request)
        {
            var genre = await _mediator.Send(request);
            return Ok(genre);
        }
    }
}
