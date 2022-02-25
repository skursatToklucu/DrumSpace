using System.Threading;
using System.Threading.Tasks;
using DrumSpace.Application.Common.Interfaces;
using MediatR;

namespace DrumSpace.Application.Accounts.Commands.VerificationCode
{
    public class VerificationCodeQueryHandler : IRequestHandler<VerificationCodeQuery, bool>
    {
        private readonly IIdentityService _identityService;
        private readonly IUserService _userService;
        private readonly ICurrentUserService _currentUser;

        public VerificationCodeQueryHandler(IIdentityService identityService, IUserService userService,
            ICurrentUserService currentUser)
        {
            _identityService = identityService;
            _userService = userService;
            _currentUser = currentUser;
        }

        public async Task<bool> Handle(VerificationCodeQuery request, CancellationToken cancellationToken)
        {
            var isVerificationCode = await _identityService.IsVerificationCodeExist(request.VerificationCode);
            var userId = _currentUser.UserId;

            if (isVerificationCode)
            {
                var result = await _userService.UpdateVerification(userId, true);
                return result.Succeeded;
            }

            var newResult = await _userService.UpdateVerification(userId, false);
            return newResult.Succeeded;
        }
    }
}