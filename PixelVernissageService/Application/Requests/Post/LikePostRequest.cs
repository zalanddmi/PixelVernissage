using MediatR;

namespace PVS.Application.Requests.Post
{
    public record LikePostRequest(long Id) : IRequest;
}
