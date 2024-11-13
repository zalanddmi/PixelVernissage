namespace PVS.Application.Models
{
    public class CommentModel
    {
        public long Id { get; set; }
        public long? ParentId { get; set; }
        public string Text { get; set; }
        public EntityModel User { get; set; }
        public ImageModel? UserImage { get; set; }
        public bool IsDeleted = false;
    }
}
