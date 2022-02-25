using System.Threading;
using System.Threading.Tasks;
using DrumSpace.Application.Common.Interfaces;
using DrumSpace.Application.Common.Models;
using DrumSpace.Application.Common.Models.Response;
using MediatR;

namespace DrumSpace.Application.Users.Commands.AssignUserToRole
{
    public class AssignUserToRolesCommandHandler : IRequestHandler<AssignUserToRolesCommand, SingleResponse<bool>>
    {
        private readonly IIdentityService _identityService;

        public AssignUserToRolesCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<SingleResponse<bool>> Handle(AssignUserToRolesCommand request, CancellationToken cancellationToken)
        {
            SingleResponse<bool> response = new();
            Result result = await _identityService.AssignUserToRoles(request.UserId, request.RoleIds);
            response.Data = result.Succeeded;
            response.ErrorMessages.AddRange(result.Errors);
            return response;
        }
    }
}