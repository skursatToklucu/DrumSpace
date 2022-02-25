using System.Threading;
using System.Threading.Tasks;
using DrumSpace.Application.Common.Interfaces;
using DrumSpace.Application.Common.Models;
using DrumSpace.Application.Common.Models.Response;
using MediatR;

namespace DrumSpace.Application.Roles.Commands.CreateRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, SingleResponse<bool>>
    {
        private readonly IRoleService _roleService;

        public CreateRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<SingleResponse<bool>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            SingleResponse<bool> response = new();
            Result result = await _roleService.CreateRoleAsync(request.Name);
            response.Data = result.Succeeded;
            response.ErrorMessages.AddRange(result.Errors);
            return response;
        }
    }
}