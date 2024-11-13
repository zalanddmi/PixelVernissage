using MediatR;
using PVS.Application.Requests.Post;
using PVS.Domain.Interfaces.Repositories;
using PVS.Domain.Interfaces.Services;
using PVS.Server.Exceptions;

namespace PVS.Server.Handlers.Post
{
    public class ArchivePostRequestHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService) : IRequestHandler<ArchivePostRequest>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public async Task Handle(ArchivePostRequest request, CancellationToken cancellationToken)
        {
            if (_currentUserService.CurrentUserId == null)
            {
                throw new NotFoundException("Id текущего пользователя отсутствует");
            }
            var userRepository = _unitOfWork.GetRepository<PVS.Domain.Entities.User>();
            var user = await userRepository.GetAsync(user => user.IdUser == _currentUserService.CurrentUserId)
                ?? throw new NotFoundException("Пользователь не найден");
            var postRepository = _unitOfWork.GetRepository<PVS.Domain.Entities.Post>();
            var post = await postRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException($"Пост по id = {request.Id} не найден");
            if (post.User != user)
            {
                throw new ForbiddenException("Доступ к данному посту запрещен");
            }
            post.IsArhcive = !post.IsArhcive;
            await _unitOfWork.CommitAsync();
        }
    }
}
