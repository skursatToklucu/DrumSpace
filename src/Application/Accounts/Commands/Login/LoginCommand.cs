using DrumSpace.Application.Common.Models.Response;
using MediatR;

namespace DrumSpace.Application.Accounts.Commands.Login
{
    public class LoginCommand : IRequest<SingleResponse<string>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}