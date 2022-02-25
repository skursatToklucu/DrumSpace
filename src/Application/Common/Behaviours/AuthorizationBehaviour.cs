using DrumSpace.Application.Common.Exceptions;
using DrumSpace.Application.Common.Interfaces;
using DrumSpace.Application.Common.Security;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
// ReSharper disable All

namespace DrumSpace.Application.Common.Behaviours
{
    public class AuthorizationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IIdentityService _identityService;
        private readonly ICurrentUserService _currentUserService;

        public AuthorizationBehaviour(ICurrentUserService currentUserService, IIdentityService identityService)
        {
            _identityService = identityService;
            _currentUserService = currentUserService;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            List<AuthorizeAttribute> authorizeAttributes = request.GetType().GetCustomAttributes<AuthorizeAttribute>().ToList();

            if (authorizeAttributes.Any() == false) return await next();
            
            // Must be authenticated user
            if (_currentUserService.UserId == null)
            {
                throw new UnauthorizedAccessException();
            }

            // Role-based authorization
            List<AuthorizeAttribute> authorizeAttributesWithRoles = authorizeAttributes.Where(a => !string.IsNullOrWhiteSpace(a.Roles)).ToList();

            if (authorizeAttributesWithRoles.Any())
            {
                foreach (string[] roles in authorizeAttributesWithRoles.Select(a => a.Roles.Split(',')))
                {
                    bool authorized = false;
                    foreach (string role in roles)
                    {
                        bool isInRole = await _identityService.IsInRoleAsync(_currentUserService.UserId, role.Trim());
                        if (isInRole == false) continue;
                        authorized = true;
                        break;
                    }

                    // Must be a member of at least one role in roles
                    if (authorized == false)
                    {
                        throw new ForbiddenAccessException();
                    }
                }
            }

            // Policy-based authorization
            List<AuthorizeAttribute> authorizeAttributesWithPolicies = authorizeAttributes.Where(a => !string.IsNullOrWhiteSpace(a.Policy)).ToList();
            if (authorizeAttributesWithPolicies.Any() == false) return await next();

            foreach (string policy in authorizeAttributesWithPolicies.Select(a => a.Policy))
            {
                bool authorized = await _identityService.AuthorizeAsync(_currentUserService.UserId, policy);

                if (authorized == false)
                {
                    throw new ForbiddenAccessException();
                }
            }

            // User is authorized / authorization not required
            return await next();
        }
    }
}