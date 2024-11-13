using MediatR;
using PVS.Application.Responses.Post;

namespace PVS.Application.Requests.Post
{
    public record GetPostRequest(long Id) : IRequest<GetPostResponse>;
}
