using MediatR;

namespace PVS.Application.Requests.Account
{
    public record GetNicknameRequest() : IRequest<string>;
}
