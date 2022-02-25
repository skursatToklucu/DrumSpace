using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DrumSpace.Application.Common.Interfaces;
using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Domain.Entities;
using MediatR;

namespace DrumSpace.Application.Menus.Commands.AssignRoleToMenu
{
    public class AssignRoleToMenuCommandHandler : IRequestHandler<AssignRoleToMenuCommand, SingleResponse<bool>>
    {
        private readonly IApplicationDbContext _context;

        public AssignRoleToMenuCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SingleResponse<bool>> Handle(AssignRoleToMenuCommand request, CancellationToken cancellationToken)
        {
            List<MenuRole> menuRoles = request.Roles.Select(c => new MenuRole
            {
                MenuId = request.MenuId,
                RoleId = c
            }).ToList();

            _context.MenuRoles.AddRange(menuRoles);

            return new SingleResponse<bool>()
            {
                Data = await _context.SaveChangesAsync(cancellationToken) > 0
            };
        }
    }
}