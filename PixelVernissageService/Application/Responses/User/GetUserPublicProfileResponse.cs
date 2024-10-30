using PVS.Application.Models;

namespace PVS.Application.Responses.User
{
    public class GetUserPublicProfileResponse
    {
        public long Id { get; set; }
        public required string Nickname { get; set; }
        public string? FIO { get; set; }
        public string? Phonenumber { get; set; }
        public string? Email { get; set; }
        public string? Description { get; set; }
        public ImageModel? Image { get; set; }
    }
}
