using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PVS.Application.Requests.Cost;

namespace PVS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController(IMediator mediator) : Controller
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateComment(CreateCommentRequest request)
        {
            long id = await _mediator.Send(request);
            return Ok(id);
        }
    }
}
