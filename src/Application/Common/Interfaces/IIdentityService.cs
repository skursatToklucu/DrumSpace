using System.Collections.Generic;
using DrumSpace.Application.Common.Models;
using System.Threading.Tasks;
using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Application.Roles.Queries.Dtos;

namespace DrumSpace.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<Result> AssignUserToRoles(string userId, List<string> roleIds);

        Task<bool> IsInRoleAsync(string userId, string role);

        Task<bool> AuthorizeAsync(string userId, string policyName);

        Task<string> GenerateEmailConfirmationTokenAsync(string userId);

        Task<bool> ConfirmEmail(string email, string token);

        Task<bool> IsVerificationCodeExist(int verificationCode);
    }
}