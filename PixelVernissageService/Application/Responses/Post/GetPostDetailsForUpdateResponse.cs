using PVS.Application.Models;

namespace PVS.Application.Responses.Post
{
    public class GetPostDetailsForUpdateResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ImageModel Image { get; set; }
        public string? Description { get; set; }
        public List<string> Hashtags { get; set; }
        public EntityModel Genre { get; set; }
        public float Cost { get; set; }
        public bool IsSold { get; set; }
        public bool IsArhcive { get; set; }
        public EntityModel User { get; set; }
        public ImageModel? UserImage { get; set; }
    }
}
