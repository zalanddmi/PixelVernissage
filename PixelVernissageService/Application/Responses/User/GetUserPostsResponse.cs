using PVS.Application.Models;

namespace PVS.Application.Responses.User
{
    public class GetUserPostsResponse
    {
        public List<UserPostModel>? Posts { get; set; }
    }
}
