using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrumSpace.Application.Common.Interfaces;
using DrumSpace.Application.Common.Mappings;
using DrumSpace.Application.Common.Models;
using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Application.Roles.Queries.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DrumSpace.Infrastructure.Identity
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<Result> CreateRoleAsync(string name)
        {
            IdentityRole role = new(name);
            IdentityResult result = await _roleManager.CreateAsync(role);
            return result.ToApplicationResult();
        }

        public async Task<Result> DeleteRoleAsync(string roleId)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(roleId);
            if (role == null) return Result.Failure(new[] {"Role not found"});
            IdentityResult result = await _roleManager.DeleteAsync(role);
            return result.ToApplicationResult();
        }

        public async Task<PagedResponse<RoleDto>> Roles(int pageNumber, int pageSize)
        {
            return await _roleManager.Roles
                .Select(c => new RoleDto {Id = c.Id, Name = c.Name})
                .PaginatedListAsync(pageNumber, pageSize);
        }

        public async Task<SingleResponse<RoleDto>> Detail(string roleId)
        {
            return new SingleResponse<RoleDto>
            {
                Data = await _roleManager.Roles.Where(x => x.Id == roleId)
                    .Select(c => new RoleDto {Id = c.Id, Name = c.Name}).FirstOrDefaultAsync()
            };
        }

        public async Task<List<RoleDto>> Roles(List<string> roleIds)
        {
            return await _roleManager.Roles.Where(c => roleIds.Contains(c.Id))
                .Select(c => new RoleDto {Id = c.Id, Name = c.Name}).ToListAsync();
        }
    }
}