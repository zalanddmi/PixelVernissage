using MediatR;
using PVS.Application.Requests.Account;
using PVS.Domain.Interfaces.Repositories;
using PVS.Domain.Interfaces.Services;
using PVS.Server.Exceptions;

namespace PVS.Server.Handlers.Account
{
    public class GetNicknameRequestHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService) : IRequestHandler<GetNicknameRequest, string>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public async Task<string> Handle(GetNicknameRequest request, CancellationToken cancellationToken)
        {
            if (_currentUserService.CurrentUserId == null)
            {
                throw new NotFoundException("Id текущего пользователя отсутствует");
            }
            var userRepository = _unitOfWork.GetRepository<PVS.Domain.Entities.User>();
            var users = await userRepository.GetAllAsync();
            var user = users.FirstOrDefault(user => user.IdUser == _currentUserService.CurrentUserId) ?? throw new NotFoundException("Пользователь не найден");
            return user.Nickname;
        }
    }
}
