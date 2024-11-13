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
    public class GetPostRequestHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMinioClient minioClient)
        : IRequestHandler<GetPostRequest, GetPostResponse>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ICurrentUserService _currentUserService = currentUserService;
        private readonly IMinioClient _minioClient = minioClient;

        public async Task<GetPostResponse> Handle(GetPostRequest request, CancellationToken cancellationToken)
        {
            var postRepository = _unitOfWork.GetRepository<PVS.Domain.Entities.Post>();
            var post = await postRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException($"Пост по id = {request.Id} не найден");
            if (post.IsArhcive)
            {
                throw new ForbiddenException("Доступ к данному посту запрещен");
            }
            ImageModel image = await GetImageModel(post.ImageId);
            ImageModel? userImage = post.User.ImageId == null ? null : await GetImageModel((long)post.User.ImageId);
            EntityModel userModel = new() { Id = post.UserId, Name = post.User.Nickname };
            List<CommentModel> comments = [];
            if (post.Comments.Count > 0)
            {
                foreach (PVS.Domain.Entities.Comment comment in post.Comments)
                {
                    ImageModel? userImageComment = comment.User.ImageId == null ? null : await GetImageModel((long)comment.User.ImageId);
                    EntityModel userComment = new() { Id = comment.UserId, Name = comment.User.Nickname };
                    CommentModel commentModel = new()
                        { Id = comment.Id, ParentId = comment.ParentId, Text = comment.Text, User = userComment, UserImage = userImageComment, IsDeleted = comment.IsDeleted };
                    comments.Add(commentModel);
                }
            }
            bool isLiked = _currentUserService.CurrentUserId != null;
            if (isLiked)
            {
                var userRepository = _unitOfWork.GetRepository<PVS.Domain.Entities.User>();
                var user = await userRepository.GetAsync(user => user.IdUser == _currentUserService.CurrentUserId);
                if (user != null)
                {
                    isLiked = user.Likes.FirstOrDefault(l => l.PostId == post.Id) != null;
                }
            }
            var likeRepository = _unitOfWork.GetRepository<Like>();
            var likes = await likeRepository.FindAsNoTrackingAsync(l => l.PostId == post.Id);
            List<string> hashtags = post.Hashtags.Select(h => h.Name).ToList();
            GetPostResponse response = new()
            {
                Id = post.Id,
                Name = post.Name,
                Image = image,
                Description = post.Description,
                Hashtags = hashtags,
                Genre = post.Genre.Name,
                Cost = post.Cost,
                IsSold = post.IsSold,
                IsLiked = isLiked,
                CountLikes = likes.Count(),
                User = userModel,
                UserImage = userImage,
                Comments = comments
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
