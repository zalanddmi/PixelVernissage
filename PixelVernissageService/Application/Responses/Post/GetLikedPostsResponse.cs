using PVS.Application.Models;

namespace PVS.Application.Responses.Post
{
    public class GetLikedPostsResponse
    {
        public List<LikedPostModel> Posts { get; set; } = [];
    }
}
