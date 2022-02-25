using DrumSpace.Application.Common.Models.Response;
using MediatR;

namespace DrumSpace.Application.Roles.Commands.CreateRole
{
    public class CreateRoleCommand : IRequest<SingleResponse<bool>>
    {
        public string Name { get; set; }
    }
}