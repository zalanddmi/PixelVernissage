using MediatR;
using PVS.Application.Responses.Genre;

namespace PVS.Application.Requests.Genre
{
    public record GetGenreRequest(long Id) : IRequest<GetGenreResponse>;
}
