using AutoMapper;
using MediatR;
using PVS.Application.Exceptions;
using PVS.Application.Requests.Genre;
using PVS.Application.Responses.Genre;
using PVS.Domain.Interfaces.Repositories;

namespace PVS.Server.Handlers.Genre
{
    public class GetGenreHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetGenreRequest, GetGenreResponse>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<GetGenreResponse> Handle(GetGenreRequest request, CancellationToken cancellationToken = default)
        {
            var genreRepository = _unitOfWork.GetRepository<PVS.Domain.Entities.Genre>();
            PVS.Domain.Entities.Genre? genre = await genreRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException($"Жанр по id = {request.Id} не найден");
            GetGenreResponse getGenreResponse = _mapper.Map<GetGenreResponse>(genre);
            return getGenreResponse;
        }
    }
}
