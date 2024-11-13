using MediatR;
using PVS.Application.Requests.Cost;
using PVS.Domain.Interfaces.Repositories;
using PVS.Domain.Interfaces.Services;
using PVS.Server.Exceptions;

namespace PVS.Server.Handlers.Comment
{
    public class CreateCommentRequestHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
        : IRequestHandler<CreateCommentRequest, long>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public async Task<long> Handle(CreateCommentRequest request, CancellationToken cancellationToken)
        {
            if (_currentUserService.CurrentUserId == null)
            {
                throw new NotFoundException("Id текущего пользователя отсутствует");
            }
            var userRepository = _unitOfWork.GetRepository<PVS.Domain.Entities.User>();
            var user = await userRepository.GetAsync(user => user.IdUser == _currentUserService.CurrentUserId)
                ?? throw new NotFoundException("Пользователь не найден");
            var postRepository = _unitOfWork.GetRepository<PVS.Domain.Entities.Post>();
            var post = await postRepository.GetByIdAsync(request.PostId) ?? throw new NotFoundException($"Пост по id = {request.PostId} не найден");
            var commentRepository = _unitOfWork.GetRepository<PVS.Domain.Entities.Comment>();
            PVS.Domain.Entities.Comment? parent = null;
            if (request.ParentId != null)
            {
                parent = await commentRepository.GetAsync(c => c.Id == (long)request.ParentId && c.PostId == request.PostId) 
                    ?? throw new NotFoundException($"Комментарий по id = {request.ParentId} не найден");
            }
            PVS.Domain.Entities.Comment comment = new()
            {
                User = user,
                Post = post,
                Parent = parent,
                Text = request.Text,
            };
            await commentRepository.AddAsync(comment);
            await _unitOfWork.CommitAsync();
            return comment.Id;
        }
    }
}
