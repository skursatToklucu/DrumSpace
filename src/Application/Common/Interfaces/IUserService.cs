using System.Collections.Generic;
using System.Threading.Tasks;
using DrumSpace.Application.Common.Models;
using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Application.Users.Queries.Dtos;

namespace DrumSpace.Application.Common.Interfaces
{
    public interface IUserService
    {
        Task<string> GetUserNameAsync(string userId);
        Task<Result> DeleteUserAsync(string userId);
        Task<PagedResponse<UserDto>> Users(int pageNumber, int pageSize);
        Task<SingleResponse<string>> Login(string userName, string password);
        Task<Result> UpdateUserAsync(string userId, string userName, string email);
        Task<SingleResponse<bool>> CreateUserAsync(string email, string userName, string password);
        Task<SingleResponse<UserDto>> Detail(string userId);
        Task<List<UserDto>> Users(List<string> userIds);
        Task<UserWithRoleDto> UserRole();
        Task<Result> UpdateVerification(string userId, bool isVerification);
    }
}