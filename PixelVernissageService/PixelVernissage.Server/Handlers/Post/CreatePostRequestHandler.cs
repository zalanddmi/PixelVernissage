using MediatR;
using Minio;
using Minio.DataModel.Args;
using PVS.Application.Requests.Post;
using PVS.Domain.Entities;
using PVS.Domain.Interfaces.Repositories;
using PVS.Domain.Interfaces.Services;
using PVS.Server.Constants;
using PVS.Server.Exceptions;

namespace PVS.Server.Handlers.Post
{
    public class CreatePostRequestHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMinioClient minioClient)
        : IRequestHandler<CreatePostRequest, long>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ICurrentUserService _currentUserService = currentUserService;
        private readonly IMinioClient _minioClient = minioClient;

        public async Task<long> Handle(CreatePostRequest request, CancellationToken cancellationToken)
        {
            if (_currentUserService.CurrentUserId == null)
            {
                throw new NotFoundException("Id текущего пользователя отсутствует");
            }
            var userRepository = _unitOfWork.GetRepository<PVS.Domain.Entities.User>();
            var user = await userRepository.GetAsync(user => user.IdUser == _currentUserService.CurrentUserId)
                ?? throw new NotFoundException("Пользователь не найден");
            var genreRepository = _unitOfWork.GetRepository<PVS.Domain.Entities.Genre>();
            var genre = await genreRepository.GetByIdAsync(request.GenreId)
                ?? throw new NotFoundException($"Жанр по id = {request.GenreId} не найден");
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
            var hashtagRepository = _unitOfWork.GetRepository<Hashtag>();
            if (request.Hashtags?.Count != 0)
            {
                foreach (string hashtagName in request.Hashtags)
                {
                    Hashtag? hashtag = await hashtagRepository.GetAsync(h => h.Name == hashtagName);
                    if (hashtag == null)
                    {
                        await hashtagRepository.AddAsync(new Hashtag() { Name = hashtagName });
                    }
                }
            }
            await _unitOfWork.CommitAsync();
            var post = new PVS.Domain.Entities.Post()
            {
                Name = request.Name,
                User = user,
                Image = image,
                Description = request.Description,
                Genre = genre,
                Cost = request.Cost
            };
            List<Hashtag> hashtags = [];
            if (request.Hashtags?.Count != 0)
            {
                foreach (string hashtagName in request.Hashtags)
                {
                    Hashtag hashtag = await hashtagRepository.GetAsync(h => h.Name == hashtagName);
                    hashtags.Add(hashtag);
                }
            }
            if (hashtags.Count > 0)
            {
                post.Hashtags = hashtags;
            }
            var postRepository = _unitOfWork.GetRepository<PVS.Domain.Entities.Post>();
            await postRepository.AddAsync(post);
            await _unitOfWork.CommitAsync();
            return post.Id;
        }
    }
}
