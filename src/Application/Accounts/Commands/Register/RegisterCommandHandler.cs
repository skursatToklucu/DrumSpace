using System.Threading;
using System.Threading.Tasks;
using DrumSpace.Application.Common.Interfaces;
using DrumSpace.Application.Common.Models.Response;
using MediatR;

namespace DrumSpace.Application.Accounts.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, SingleResponse<bool>>
    {
        private readonly IUserService _userService;

        public RegisterCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<SingleResponse<bool>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            return await _userService.CreateUserAsync(request.Email, request.UserName, request.Password);
        }
    }
}