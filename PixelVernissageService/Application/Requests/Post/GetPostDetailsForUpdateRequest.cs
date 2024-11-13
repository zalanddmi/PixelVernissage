using MediatR;
using PVS.Application.Responses.Post;

namespace PVS.Application.Requests.Post
{
    public record GetPostDetailsForUpdateRequest(long Id) : IRequest<GetPostDetailsForUpdateResponse>;
}
