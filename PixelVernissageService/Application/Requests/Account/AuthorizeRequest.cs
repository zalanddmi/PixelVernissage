using MediatR;

namespace PVS.Application.Requests.Account
{
    public record AuthorizeRequest(string UserId, string Username, string? FIO, string? Email) : IRequest;
}
