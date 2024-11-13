using MediatR;
using PVS.Application.Requests.Post;
using PVS.Domain.Entities;
using PVS.Domain.Interfaces.Repositories;
using PVS.Domain.Interfaces.Services;
using PVS.Server.Exceptions;

namespace PVS.Server.Handlers.Post
{
    public class LikePostRequestHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService) : IRequestHandler<LikePostRequest>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public async Task Handle(LikePostRequest request, CancellationToken cancellationToken)
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
            Like? like = user.Likes.FirstOrDefault(l => l.PostId == request.Id);
            if (like == null)
            {
                Like newLike = new() { Post = post, User = user };
                var likeRepository = _unitOfWork.GetRepository<Like>();
                await likeRepository.AddAsync(newLike);
            }
            else
            {
                user.Likes.Remove(like);
            }
            await _unitOfWork.CommitAsync();
        }
    }
}
