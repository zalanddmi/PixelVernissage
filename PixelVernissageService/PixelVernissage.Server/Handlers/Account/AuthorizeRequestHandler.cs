using MediatR;
using PVS.Application.Requests.Account;
using PVS.Domain.Interfaces.Repositories;

namespace PVS.Server.Handlers.Account
{
    public class AuthorizeRequestHandler(IUnitOfWork unitOfWork) : IRequestHandler<AuthorizeRequest>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(AuthorizeRequest request, CancellationToken cancellationToken)
        {
            var userRepository = _unitOfWork.GetRepository<PVS.Domain.Entities.User>();
            var user = userRepository.GetAllAsync().Result.FirstOrDefault(user => user.IdUser == request.UserId);
            if (user != null)
            {
                return;
            }
            string nickname = request.Username;
            var userNickame = userRepository.GetAllAsync().Result.FirstOrDefault(user => user.Nickname == nickname);
            if (userNickame != null)
            {
                int i = 1;
                while (true)
                {
                    nickname = request.Username + i;
                    var userNickname = userRepository.GetAllAsync().Result.FirstOrDefault(user => user.Nickname == nickname);
                    if (userNickname == null)
                    {
                        break;
                    }
                    i++;
                }
            }
            PVS.Domain.Entities.User newUser = new()
            {
                IdUser = request.UserId,
                Username = request.Username,
                Nickname = nickname,
                FIO = request.FIO,
                Email = request.Email
            };
            await userRepository.AddAsync(newUser);
            await _unitOfWork.CommitAsync();
        }
    }
}
