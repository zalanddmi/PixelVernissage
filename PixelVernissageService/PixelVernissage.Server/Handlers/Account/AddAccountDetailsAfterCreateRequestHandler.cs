using MediatR;
using Minio;
using Minio.DataModel.Args;
using PVS.Application.Requests.Account;
using PVS.Domain.Entities;
using PVS.Domain.Interfaces.Repositories;
using PVS.Domain.Interfaces.Services;
using PVS.Infrastructure.Context;
using PVS.Server.Constants;
using PVS.Server.Exceptions;

namespace PVS.Server.Handlers.Account
{
    public class AddAccountDetailsAfterCreateRequestHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMinioClient minioClient, PvsContext context)
        : IRequestHandler<AddAccountDetailsAfterCreateRequest>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ICurrentUserService _currentUserService = currentUserService;
        private readonly IMinioClient _minioClient = minioClient;
        private readonly PvsContext _context = context;

        public async Task Handle(AddAccountDetailsAfterCreateRequest request, CancellationToken cancellationToken)
        {
            if (_currentUserService.CurrentUserId == null)
            {
                throw new NotFoundException("Id текущего пользователя отсутствует");
            }
            var userRepository = _unitOfWork.GetRepository<PVS.Domain.Entities.User>();
            var user = await userRepository.GetAsync(user => user.IdUser == _currentUserService.CurrentUserId) ?? throw new NotFoundException("Пользователь не найден");
            user.Nickname = request.Nickname;
            user.Phonenumber = request.Phonenumber;
            user.Description = request.Description;
            if (request.Image != null)
            {
                using Stream stream = request.Image.OpenReadStream();
                string path = Guid.NewGuid().ToString();
                await _minioClient.PutObjectAsync(new PutObjectArgs()
                    .WithBucket(ServerConstants.BucketName)
                    .WithObject(path)
                    .WithObjectSize(request.Image.Length)
                    .WithStreamData(stream)
                    .WithContentType(request.Image.ContentType), cancellationToken);
                var imageRepository = _unitOfWork.GetRepository<Image>();
                Image image = new() { Name = Path.GetFileNameWithoutExtension(request.Image.FileName), Path = path };
                await imageRepository.AddAsync(image);
                await _unitOfWork.CommitAsync();
                user.Image = image;
            }
            user.ModifiedAt = DateTime.UtcNow;
            await _unitOfWork.CommitAsync();
        }
    }
}
