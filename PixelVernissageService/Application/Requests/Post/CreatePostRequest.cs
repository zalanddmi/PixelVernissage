using MediatR;
using Microsoft.AspNetCore.Http;

namespace PVS.Application.Requests.Post
{
    public class CreatePostRequest : IRequest<long>
    {
        public required string Name { get; set; }
        public required IFormFile Image { get; set; }
        public string? Description { get; set; }
        public List<string>? Hashtags { get; set; } = [];
        public required long GenreId { get; set; }
        public required float Cost { get; set; } = 0;
    }
}
