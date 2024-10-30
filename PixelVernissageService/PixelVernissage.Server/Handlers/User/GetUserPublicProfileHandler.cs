using MediatR;
using Minio;
using Minio.DataModel.Args;
using Minio.DataModel;
using PVS.Application.Models;
using PVS.Application.Requests.User;
using PVS.Application.Responses.User;
using PVS.Domain.Entities;
using PVS.Domain.Interfaces.Repositories;
using PVS.Server.Constants;
using PVS.Server.Exceptions;

namespace PVS.Server.Handlers.User
{
    public class GetUserPublicProfileHandler(IUnitOfWork unitOfWork, IMinioClient minioClient)
        : IRequestHandler<GetUserPublicProfileRequest, GetUserPublicProfileResponse>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMinioClient _minioClient = minioClient;

        public async Task<GetUserPublicProfileResponse> Handle(GetUserPublicProfileRequest request, CancellationToken cancellationToken)
        {
            var userRepository = _unitOfWork.GetRepository<PVS.Domain.Entities.User>();
            var user = await userRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException($"Пользователь по id = {request.Id} не найден");
            ImageModel? imageModel = await GetImageModel(user.ImageId);
            GetUserPublicProfileResponse profile = new()
            {
                Id = user.Id,
                Nickname = user.Nickname,
                FIO = user.FIO,
                Phonenumber = user.Phonenumber,
                Email = user.Email,
                Description = user.Description,
                Image = imageModel
            };
            return profile;
        }

        private async Task<ImageModel?> GetImageModel(long? imageId)
        {
            if (imageId == null)
            {
                return null;
            }
            var imageRepository = _unitOfWork.GetRepository<Image>();
            Image image = await imageRepository.GetByIdAsync((long)imageId) ?? throw new NotFoundException($"Изображение по id = {imageId} не найден");
            StatObjectArgs statObjectArgs = new StatObjectArgs()
                                    .WithBucket(ServerConstants.BucketName)
                                    .WithObject(image.Path);
            ObjectStat objectStat = await _minioClient.StatObjectAsync(statObjectArgs);
            using (var memoryStream = new MemoryStream())
            {
                GetObjectArgs getObjectArgs = new GetObjectArgs()
                                    .WithBucket(ServerConstants.BucketName)
                                    .WithObject(image.Path)
                                    .WithCallbackStream((stream) =>
                                    {
                                        stream.CopyTo(memoryStream);
                                    });
                await _minioClient.GetObjectAsync(getObjectArgs);
                byte[] imageBytes = memoryStream.ToArray();
                ImageModel model = new()
                {
                    ImageData = imageBytes,
                    ContentType = objectStat.ContentType,
                    Name = image.Name,
                    Path = image.Path
                };
                return model;
            }    
        }
    }
}
