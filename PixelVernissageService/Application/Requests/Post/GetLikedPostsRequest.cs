using MediatR;
using PVS.Application.Responses.Post;

namespace PVS.Application.Requests.Post
{
    public record GetLikedPostsRequest() : IRequest<GetLikedPostsResponse>;
}
