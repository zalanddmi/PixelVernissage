using MediatR;
using PVS.Application.Responses.Genre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVS.Application.Requests.Genre
{
    public record GetGenreRequest(long Id) : IRequest<GetGenreResponse>
    {
    }
}
