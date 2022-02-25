using System.Threading;
using System.Threading.Tasks;
using DrumSpace.Application.Common.Interfaces;
using MediatR;

namespace DrumSpace.Application.Accounts.Commands.ConfirmEmail
{
    public class ConfirmCommandHandler : IRequestHandler<ConfirmCommand, bool>
    {
        private readonly IIdentityService _identityService;
        
        public ConfirmCommandHandler(IIdentityService identityService) => _identityService = identityService;
        
        public Task<bool> Handle(ConfirmCommand request, CancellationToken cancellationToken)
        {
           return _identityService.ConfirmEmail(request.Email, request.Token);
        }
    }
}