using System.Threading;
using System.Threading.Tasks;
using DrumSpace.Application.Common.Interfaces;
using DrumSpace.Application.Common.Models;
using DrumSpace.Application.Common.Models.Response;
using MediatR;

namespace DrumSpace.Application.Roles.Commands.DeleteRole
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, SingleResponse<bool>>
    {
        private readonly IRoleService _roleService;

        public DeleteRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<SingleResponse<bool>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            SingleResponse<bool> response = new();
            Result result = await _roleService.DeleteRoleAsync(request.RoleId);
            response.Data = result.Succeeded;
            response.ErrorMessages.AddRange(result.Errors);
            return response;
        }
    }
}