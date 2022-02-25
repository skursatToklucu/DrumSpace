using DrumSpace.Application.Common.Interfaces;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
// ReSharper disable All

namespace DrumSpace.Application.Common.Behaviours
{
    public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger<TRequest> _logger;
        private readonly IUserService _userService;
        private readonly ICurrentUserService _currentUserService;

        public LoggingBehaviour(ILogger<TRequest> logger, ICurrentUserService currentUserService, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
            _currentUserService = currentUserService;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            string requestName = typeof(TRequest).Name;
            string userId = _currentUserService.UserId ?? string.Empty;
            string userName = string.Empty;

            if (string.IsNullOrEmpty(userId) == false)
            {
                userName = await _userService.GetUserNameAsync(userId);
            }

            _logger.LogInformation("DrumSpace Request: {Name} {@UserId} {@UserName} {@Request}", requestName, userId, userName, request);
        }
    }
}