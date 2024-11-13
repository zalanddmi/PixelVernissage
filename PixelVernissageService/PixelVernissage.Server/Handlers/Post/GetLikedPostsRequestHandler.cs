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
    public class GetLikedPostsRequestHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMinioClient minioClient)
        : IRequestHandler<GetLikedPostsRequest, GetLikedPostsResponse>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ICurrentUserService _currentUserService = currentUserService;
        private readonly IMinioClient _minioClient = minioClient;

        public async Task<GetLikedPostsResponse> Handle(GetLikedPostsRequest request, CancellationToken cancellationToken)
        {
            if (_currentUserService.CurrentUserId == null)
            {
                throw new NotFoundException("Id текущего пользователя отсутствует");
            }
            var userRepository = _unitOfWork.GetRepository<PVS.Domain.Entities.User>();
            var user = await userRepository.GetAsync(user => user.IdUser == _currentUserService.CurrentUserId)
                ?? throw new NotFoundException("Пользователь не найден");
            var likedPosts = user.Likes.Select(lp => lp.Post).ToList();
            if (likedPosts.Count == 0)
            {
                return new GetLikedPostsResponse();
            }
            List<LikedPostModel> likedPostModels = [];
            foreach (var likedPost in likedPosts)
            {
                ImageModel image = await GetImageModel(likedPost.ImageId);
                ImageModel? userImage = null;
                if (likedPost.ImageId != null)
                {
                    userImage = await GetImageModel((long)likedPost.User.ImageId);
                }
                EntityModel userModel = new() { Id = likedPost.UserId, Name = likedPost.User.Nickname };
                LikedPostModel likedPostModel = new() { Id = likedPost.Id, Name = likedPost.Name, Image = image, User = userModel, UserImage = userImage };
                likedPostModels.Add(likedPostModel);
            }
            return new GetLikedPostsResponse() { Posts = likedPostModels };
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
