using System;
using System.Collections.Generic;
using DrumSpace.Application.Common.Interfaces;
using DrumSpace.Application.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;

namespace DrumSpace.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;
        private readonly ICurrentUserService _currentUser;

        public IdentityService(
            RoleManager<IdentityRole> roleManager,
            IHttpContextAccessor httpContextAccessor,
            UserManager<ApplicationUser> userManager,
            IAuthorizationService authorizationService,
            IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory, ICurrentUserService currentUser)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _authorizationService = authorizationService;
            _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
            _currentUser = currentUser;
        }

        public async Task<Result> AssignUserToRoles(string userId, List<string> roleIds)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            IQueryable<string> roleNames = _roleManager.Roles.Where(c => roleIds.Contains(c.Id)).Select(c => c.Name);
            IdentityResult result = await _userManager.AddToRolesAsync(user, roleNames);
            return result.ToApplicationResult();
        }

        public async Task<bool> IsInRoleAsync(string userId, string role)
        {
            ApplicationUser user = _userManager.Users.SingleOrDefault(u => u.Id == userId);
            return await _userManager.IsInRoleAsync(user, role);
        }

        public async Task<bool> AuthorizeAsync(string userId, string policyName)
        {
            ApplicationUser user = _userManager.Users.SingleOrDefault(u => u.Id == userId);
            ClaimsPrincipal principal = await _userClaimsPrincipalFactory.CreateAsync(user);
            AuthorizationResult result = await _authorizationService.AuthorizeAsync(principal, policyName);

            return result.Succeeded;
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(string userId)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            return WebEncoders.Base64UrlEncode(
                Encoding.UTF8.GetBytes(await _userManager.GenerateEmailConfirmationTokenAsync(user)));
        }

        public async Task<bool> ConfirmEmail(string email, string token)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(email);
            token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token));
            IdentityResult result = await _userManager.ConfirmEmailAsync(user, token);
            return result.Succeeded;
        }

        public async Task<bool> IsVerificationCodeExist(int verificationCode)
        {
            ApplicationUser user = await _userManager.Users
                .Where(applicationUser => applicationUser.Id == _currentUser.UserId).FirstOrDefaultAsync();

            TimeSpan diff = DateTime.Now.Subtract(user.VerificationCodeCreatedAt);

            if (diff.Minutes < 3)
            {
                return false;
            }
            return true;
        }
    }
}