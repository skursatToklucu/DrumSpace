using System.Collections.Generic;
using System.Threading.Tasks;
using DrumSpace.Application.Common.Models;
using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Application.Roles.Queries.Dtos;

namespace DrumSpace.Application.Common.Interfaces
{
    public interface IRoleService
    {
        Task<Result> CreateRoleAsync(string name);
        Task<Result> DeleteRoleAsync(string roleId);
        Task<PagedResponse<RoleDto>> Roles(int pageNumber, int pageSize);
        Task<SingleResponse<RoleDto>> Detail(string roleId);
        Task<List<RoleDto>> Roles(List<string> roleIds);
    }
}