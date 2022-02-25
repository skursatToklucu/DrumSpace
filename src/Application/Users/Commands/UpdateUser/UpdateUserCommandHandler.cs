using System.Threading;
using System.Threading.Tasks;
using DrumSpace.Application.Common.Interfaces;
using DrumSpace.Application.Common.Models;
using DrumSpace.Application.Common.Models.Response;
using MediatR;

namespace DrumSpace.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, SingleResponse<bool>>
    {
        private readonly IUserService _userService;

        public UpdateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<SingleResponse<bool>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            SingleResponse<bool> response = new();
            Result result = await _userService.UpdateUserAsync(request.UserId, request.UserName, request.Email);
            response.Data = result.Succeeded;
            response.ErrorMessages.AddRange(result.Errors);
            return response;
        }
    }
}