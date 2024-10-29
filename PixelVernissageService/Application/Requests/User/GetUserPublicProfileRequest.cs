using MediatR;
using PVS.Application.Responses.User;

namespace PVS.Application.Requests.User
{
    public record GetUserPublicProfileRequest(long Id) : IRequest<GetUserPublicProfileResponse>;
}
