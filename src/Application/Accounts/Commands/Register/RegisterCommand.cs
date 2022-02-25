using DrumSpace.Application.Common.Models.Response;
using MediatR;

namespace DrumSpace.Application.Accounts.Commands.Register
{
    public class RegisterCommand : IRequest<SingleResponse<bool>>
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}