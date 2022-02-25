using System.Threading;
using System.Threading.Tasks;
using DrumSpace.Application.Common.Interfaces;
using DrumSpace.Application.Common.Models;
using DrumSpace.Application.Common.Models.Response;
using MediatR;

namespace DrumSpace.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, SingleResponse<bool>>
    {
        private readonly IUserService _userService;

        public DeleteUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<SingleResponse<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            SingleResponse<bool> response = new();
            Result result = await _userService.DeleteUserAsync(request.UserId);
            response.Data = result.Succeeded;
            response.ErrorMessages.AddRange(result.Errors);
            return response;
        }
    }
}