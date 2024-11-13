namespace PVS.Application.Models
{
    public class LikedPostModel
    {
        public required long Id { get; set; }
        public required string Name { get; set; }
        public required ImageModel Image { get; set; }
        public required EntityModel User { get; set; }
        public required ImageModel? UserImage { get; set; }
    }
}
