namespace PVS.Application.Models
{
    public class UserPostModel
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public required ImageModel Image { get; set; }
    }
}
