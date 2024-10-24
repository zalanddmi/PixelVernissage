using AutoMapper;
using MediatR;
using PVS.Application.Requests.Genre;
using PVS.Application.Responses.Genre;
using PVS.Domain.Interfaces.Repositories;

namespace PVS.Server.Handlers.Genre
{
    public class GetGenreHandler : IRequestHandler<GetGenreRequest, GetGenreResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetGenreHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetGenreResponse> Handle(GetGenreRequest request, CancellationToken cancellationToken = default)
        {
            var genreRepository = _unitOfWork.GetRepository<PVS.Domain.Entities.Genre>();
            PVS.Domain.Entities.Genre? genre = await genreRepository.GetByIdAsync(request.Id) ?? throw new ArgumentNullException(nameof(request.Id));
            GetGenreResponse getGenreResponse = _mapper.Map<GetGenreResponse>(genre);
            return getGenreResponse;
        }
    }
}
