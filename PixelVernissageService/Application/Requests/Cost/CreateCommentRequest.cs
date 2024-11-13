using MediatR;

namespace PVS.Application.Requests.Cost
{
    public class CreateCommentRequest : IRequest<long>
    {
        public required long PostId { get; set; }
        public long? ParentId { get; set; }
        public required string Text { get; set; }
    }
}
