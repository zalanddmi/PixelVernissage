using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PVS.Application.Requests.Account;

namespace PVS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IMediator mediator) : Controller
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("nickname")]
        [Authorize]
        public async Task<IActionResult> GetNickname()
        {
            string nickname = await _mediator.Send(new GetNicknameRequest());
            return Ok(nickname);
        }

        [HttpPut("details-after-create")]
        [Authorize]
        public async Task<IActionResult> AddDetailsAfterCreate(AddAccountDetailsAfterCreateRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}
