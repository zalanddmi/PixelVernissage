using MediatR;
using Microsoft.AspNetCore.Mvc;
using PVS.Application.Requests.User;
using PVS.Application.Responses.User;

namespace PVS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IMediator mediator) : Controller
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("{id}/public")]
        public async Task<IActionResult> GetUserPublicById(long id)
        {
            GetUserPublicProfileResponse user = await _mediator.Send(new GetUserPublicProfileRequest(id));
            return Ok(user);
        }

        [HttpGet("{id}/posts")]
        public async Task<IActionResult> GetUserPostsById(long id)
        {
            GetUserPostsResponse posts = await _mediator.Send(new GetUserPostsRequest(id));
            return Ok(posts);
        }
    }
}
