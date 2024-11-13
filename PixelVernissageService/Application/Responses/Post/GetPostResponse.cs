using PVS.Application.Models;

namespace PVS.Application.Responses.Post
{
    public class GetPostResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ImageModel Image { get; set; }
        public string? Description { get; set; }
        public List<string> Hashtags { get; set; } = [];
        public string Genre { get; set; }
        public float Cost { get; set; }
        public bool IsSold { get; set; }
        public bool IsLiked { get; set; }
        public int CountLikes { get; set; }
        public EntityModel User { get; set; }
        public ImageModel? UserImage { get; set; }
        public List<CommentModel> Comments { get; set; } = [];
    }
}
