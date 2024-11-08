using MediatR;
using Microsoft.AspNetCore.Http;

namespace PVS.Application.Requests.Account
{
    public class AddAccountDetailsAfterCreateRequest : IRequest
    {
        public required string Nickname { get; set; }
        public string? Phonenumber { get; set; } = null;
        public string? Description { get; set; } = null;
        public IFormFile? Image { get; set; } = null;
    }
}
