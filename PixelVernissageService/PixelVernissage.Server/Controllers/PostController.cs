using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PVS.Application.Requests.Post;
using PVS.Application.Responses.Post;

namespace PVS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController(IMediator mediator) : Controller
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(long id)
        {
            GetPostResponse response = await _mediator.Send(new GetPostRequest(id));
            return Ok(response);
        }

        [HttpGet("liked")]
        [Authorize]
        public async Task<IActionResult> GetLikedPosts()
        {
            GetLikedPostsResponse response = await _mediator.Send(new GetLikedPostsRequest());
            return Ok(response);
        }

        [HttpGet("{id}/details-for-update")]
        [Authorize]
        public async Task<IActionResult> GetPostDetailsForUpdate(long id)
        {
            GetPostDetailsForUpdateResponse response = await _mediator.Send(new GetPostDetailsForUpdateRequest(id));
            return Ok(response);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreatePost(CreatePostRequest request)
        {
            long id = await _mediator.Send(request);
            return Ok(id);
        }

        [HttpPost("{id}/like")]
        [Authorize]
        public async Task<IActionResult> LikePost(long id)
        {
            await _mediator.Send(new LikePostRequest(id));
            return Ok();
        }

        [HttpPost("{id}/archive")]
        [Authorize]
        public async Task<IActionResult> ArchivePost(long id)
        {
            await _mediator.Send(new ArchivePostRequest(id));
            return Ok();
        }
    }
}
