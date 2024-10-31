using MediatR;
using PVS.Application.Responses.User;

namespace PVS.Application.Requests.User
{
    public record GetUserPostsRequest(long userId) : IRequest<GetUserPostsResponse>;
}
