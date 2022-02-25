using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DrumSpace.Application.Common.Interfaces;
using DrumSpace.Application.Common.Mappings;
using DrumSpace.Application.Common.Models;
using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Application.Roles.Queries.Dtos;
using DrumSpace.Application.Users.Queries.Dtos;
using DrumSpace.Domain.Events;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DrumSpace.Infrastructure.Identity
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly IDomainEventService _domainEventService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ICurrentUserService _currentUser;

        public UserService(UserManager<ApplicationUser> userManager, IConfiguration configuration,
            IDomainEventService domainEventService, ICurrentUserService currentUser,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _configuration = configuration;
            _domainEventService = domainEventService;
            _currentUser = currentUser;
            _roleManager = roleManager;
        }

        public async Task<string> GetUserNameAsync(string userId)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            return user.UserName;
        }

        public async Task<Result> DeleteUserAsync(string userId)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            if (user == null) return Result.Failure(new[] {"User not found"});
            IdentityResult result = await _userManager.DeleteAsync(user);
            return result.ToApplicationResult();
        }

        //TODO: Role çekilecek
        public async Task<PagedResponse<UserDto>> Users(int pageNumber, int pageSize)
        {
            return await _userManager.Users
                .Select(c =>
                    new UserDto
                    {
                        Id = c.Id,
                        Email = c.Email,
                        UserName = c.UserName,
                    })
                .PaginatedListAsync(pageNumber, pageSize);
        }

        public async Task<SingleResponse<string>> Login(string userName, string password)
        {
            SingleResponse<string> response = new();

            ApplicationUser user = await _userManager.FindByNameAsync(userName);
            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                (string accessToken, DateTime expirationTime) = await GenerateToken(user);
                response.Data = accessToken;
            }
            else
            {
                response.ErrorMessages.Add("Wrong email or password");
            }

            return response;
        }

        public async Task<Result> UpdateUserAsync(string userId, string userName, string email)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            user.Email = email;
            user.UserName = userName;

            IdentityResult result = await _userManager.UpdateAsync(user);
            return result.ToApplicationResult();
        }

        public async Task<SingleResponse<bool>> CreateUserAsync(string email, string userName, string password)
        {
            var random = new Random();

            SingleResponse<bool> response = new();
            ApplicationUser user = new()
            {
                UserName = userName,
                Email = email,
                ImagePath = $"https://ui-avatars.com/api/?name={userName}",
                VerificationCode = random.Next(1000, 9999),
                VerificationCodeCreatedAt = DateTime.Now
            };

            IdentityResult identityResult = await _userManager.CreateAsync(user, password);

            if (identityResult.Succeeded)
            {
                //TODO: RegisteredEvent problemli bu yüzden 500 dönüyor.
                RegisteredEvent registeredEvent = new(user.Id, email) {IsPublished = true};
                await _userManager.AddToRoleAsync(user, "Standard");
                await _domainEventService.Publish(registeredEvent);

                response.Data = true;
                return response;
            }

            response.ErrorMessages.AddRange(identityResult.Errors.Select(e => e.Description));
            return response;
        }

        private async Task<(string AccessToken, DateTime ExpirationTime )> GenerateToken(ApplicationUser user)
        {
            JwtSecurityTokenHandler tokenHandler = new();
            byte[] key = Encoding.ASCII.GetBytes(_configuration["JwtBearerTokenSettings:SecretKey"]);

            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.Now.AddHours(
                    Convert.ToDouble(_configuration["JwtBearerTokenSettings:ExpiryTimeInSeconds"])),
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = _configuration["JwtBearerTokenSettings:Audience"],
                Issuer = _configuration["JwtBearerTokenSettings:Issuer"]
            };

            IList<string> roles = await _userManager.GetRolesAsync(user);
            tokenDescriptor.Subject.AddClaims(roles.Select(c => new Claim(ClaimTypes.Role, c)));

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return (tokenHandler.WriteToken(token), token.ValidTo);
        }

        public async Task<SingleResponse<UserDto>> Detail(string userId)
        {
            return new SingleResponse<UserDto>()
            {
                Data = await _userManager.Users.Where(x => x.Id == userId)
                    .Select(x => new UserDto
                    {
                        Email = x.Email,
                        Id = x.Id,
                        UserName = x.UserName
                    }).FirstOrDefaultAsync()
            };
        }

        public async Task<List<UserDto>> Users(List<string> userIds)
        {
            return await _userManager.Users.Where(x => userIds.Contains(x.Id)).Select(x => new UserDto
            {
                Email = x.Email,
                Id = x.Id,
                UserName = x.UserName
            }).ToListAsync();
        }

        public async Task<UserWithRoleDto> UserRole()
        {
            var user = await _userManager.Users.Where(user => user.Id == _currentUser.UserId).Select(user =>
                new UserWithRoleDto
                {
                    Email = user.Email,
                    UserName = user.Email,
                    Roles = new List<RoleDto>()
                }).FirstOrDefaultAsync();

            var roleIds = _userManager
                .GetRolesAsync(_userManager.Users.FirstOrDefault(applicationUser =>
                    applicationUser.Id == _currentUser.UserId)).GetAwaiter().GetResult().ToList();

            foreach (var s in roleIds)
            {
                user.Roles.Add(await _roleManager.Roles.Where(role => role.Name == s).Select(role => new RoleDto
                {
                    Id = role.Id,
                    Name = s
                }).FirstOrDefaultAsync());
            }

            return user;
        }

        public async Task<Result> UpdateVerification(string userId, bool isVerification)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(userId);

            if (isVerification)
            {
                user.EmailConfirmed = true;
                user.VerificationCode = 0000;

                IdentityResult result = await _userManager.UpdateAsync(user);
                return result.ToApplicationResult();
            }

            var random = new Random();
            user.VerificationCode = random.Next(1000, 9999);
            user.VerificationCodeCreatedAt = DateTime.Now;

            IdentityResult identityResult = await _userManager.UpdateAsync(user);
            return identityResult.ToApplicationResult();
        }
    }
}