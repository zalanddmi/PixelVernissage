using MediatR;
using Minio.DataModel.Args;
using Minio.DataModel;
using Minio;
using PVS.Application.Models;
using PVS.Application.Requests.User;
using PVS.Application.Responses.User;
using PVS.Domain.Interfaces.Repositories;
using PVS.Server.Constants;
using PVS.Server.Exceptions;
using PVS.Domain.Entities;

namespace PVS.Server.Handlers.User
{
    public class GetUserPostsHandler(IUnitOfWork unitOfWork, IMinioClient minioClient)
        : IRequestHandler<GetUserPostsRequest, GetUserPostsResponse>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMinioClient _minioClient = minioClient;

        public async Task<GetUserPostsResponse> Handle(GetUserPostsRequest request, CancellationToken cancellationToken)
        {
            var userRepository = _unitOfWork.GetRepository<PVS.Domain.Entities.User>();
            var user = await userRepository.GetByIdAsync(request.userId) ?? throw new NotFoundException($"Пользователь по id = {request.userId} не найден");
            var postRepository = _unitOfWork.GetRepository<Post>();
            var posts = postRepository.GetAllAsync().Result.Where(post => post.UserId == user.Id);
            if (!posts.Any())
            {
                return new GetUserPostsResponse();
            }
            List<UserPostModel> userPostModels = [];
            foreach (Post post in posts)
            {
                ImageModel imageModel = await GetImageModel(post.ImageId) ?? throw new NotFoundException($"Данные изображения по id поста = {post.Id} не найдены");
                UserPostModel userPostModel = new()
                {
                    Id = post.Id,
                    Name = post.Name,
                    Image = imageModel
                };
                userPostModels.Add(userPostModel);
            }
            GetUserPostsResponse response = new()
            {
                Posts = userPostModels
            };
            return response;
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
