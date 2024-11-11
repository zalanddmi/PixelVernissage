using AutoMapper;
using MediatR;
using PVS.Application.Requests.Genre;
using PVS.Application.Responses.Genre;
using PVS.Domain.Interfaces.Repositories;

namespace PVS.Server.Handlers.Genre
{
    public class GetGenresHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetGenresRequest, List<GetGenreResponse>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<List<GetGenreResponse>> Handle(GetGenresRequest request, CancellationToken cancellationToken = default)
        {
            var genreRepository = _unitOfWork.GetRepository<PVS.Domain.Entities.Genre>();
            var genres = await genreRepository.GetAllAsNoTrackingAsync();
            List<GetGenreResponse> getGenreResponses = [];
            foreach (PVS.Domain.Entities.Genre genre in genres)
            {
                GetGenreResponse getGenreResponse = _mapper.Map<GetGenreResponse>(genre);
                getGenreResponses.Add(getGenreResponse);
            }
            return getGenreResponses;
        }
    }
}
