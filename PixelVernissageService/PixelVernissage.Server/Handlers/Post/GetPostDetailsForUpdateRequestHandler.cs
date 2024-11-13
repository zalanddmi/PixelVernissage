using MediatR;
using Minio;
using Minio.DataModel.Args;
using Minio.DataModel;
using PVS.Application.Models;
using PVS.Application.Requests.Post;
using PVS.Application.Responses.Post;
using PVS.Domain.Interfaces.Repositories;
using PVS.Domain.Interfaces.Services;
using PVS.Server.Constants;
using PVS.Server.Exceptions;
using PVS.Domain.Entities;

namespace PVS.Server.Handlers.Post
{
    public class GetPostDetailsForUpdateRequestHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMinioClient minioClient)
        : IRequestHandler<GetPostDetailsForUpdateRequest, GetPostDetailsForUpdateResponse>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ICurrentUserService _currentUserService = currentUserService;
        private readonly IMinioClient _minioClient = minioClient;

        public async Task<GetPostDetailsForUpdateResponse> Handle(GetPostDetailsForUpdateRequest request, CancellationToken cancellationToken)
        {
            if (_currentUserService.CurrentUserId == null)
            {
                throw new NotFoundException("Id текущего пользователя отсутствует");
            }
            var userRepository = _unitOfWork.GetRepository<PVS.Domain.Entities.User>();
            var user = await userRepository.GetAsync(user => user.IdUser == _currentUserService.CurrentUserId) ?? throw new NotFoundException("Пользователь не найден");
            var postRepository = _unitOfWork.GetRepository<PVS.Domain.Entities.Post>();
            var post = await postRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException($"Пост по id = {request.Id} не найден");
            if (post.User != user)
            {
                throw new ForbiddenException("Доступ к данному посту запрещен");
            }
            EntityModel genre = new() { Id = post.GenreId, Name = post.Genre.Name };
            ImageModel image = await GetImageModel(post.ImageId);
            List<string> hashtags = [];
            if (post.Hashtags.Count > 0)
            {
                hashtags.AddRange(post.Hashtags.Select(h => h.Name));
            }
            GetPostDetailsForUpdateResponse response = new()
            {
                Id = post.Id,
                Name = post.Name,
                Image = image,
                Description = post.Description,
                Hashtags = hashtags,
                Genre = genre,
                Cost = post.Cost,
                IsSold = post.IsSold,
                IsArhcive = post.IsArhcive
            };
            return response;
        }

        private async Task<ImageModel> GetImageModel(long imageId)
        {
            var imageRepository = _unitOfWork.GetRepository<Image>();
            Image image = await imageRepository.GetByIdAsync(imageId) ?? throw new NotFoundException($"Изображение по id = {imageId} не найден");
            StatObjectArgs statObjectArgs = new StatObjectArgs()
                                    .WithBucket(ServerConstants.BucketName)
                                    .WithObject(image.Path);
            ObjectStat objectStat = await _minioClient.StatObjectAsync(statObjectArgs);
            using var memoryStream = new MemoryStream();
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
