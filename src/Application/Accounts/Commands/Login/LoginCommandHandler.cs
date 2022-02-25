using System.Threading;
using System.Threading.Tasks;
using DrumSpace.Application.Common.Interfaces;
using DrumSpace.Application.Common.Models.Response;
using MediatR;

namespace DrumSpace.Application.Accounts.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, SingleResponse<string>>
    {
        private readonly IUserService _userService;

        public LoginCommandHandler(IUserService userService) => _userService = userService;

        public async Task<SingleResponse<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return await _userService.Login(request.UserName, request.Password);
        }
    }
}