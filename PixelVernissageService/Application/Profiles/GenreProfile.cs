using AutoMapper;
using PVS.Application.Responses.Genre;
using PVS.Domain.Entities;

namespace PVS.Application.Profiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GetGenreResponse>();
        }
    }
}
