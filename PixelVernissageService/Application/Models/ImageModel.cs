namespace PVS.Application.Models
{
    public class ImageModel
    {
        public required byte[] ImageData { get; set; }
        public required string ContentType { get; set; }
        public required string Name { get; set; }
        public required string Path { get; set; }
    }
}
