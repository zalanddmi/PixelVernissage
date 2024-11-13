using MediatR;

namespace PVS.Application.Requests.Post
{
    public record ArchivePostRequest(long Id) : IRequest;
}
