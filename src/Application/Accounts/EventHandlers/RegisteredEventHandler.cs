using System.Threading;
using System.Threading.Tasks;
using DrumSpace.Application.Common.Interfaces;
using DrumSpace.Application.Common.Models;
using DrumSpace.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DrumSpace.Application.Accounts.EventHandlers
{
    public class RegisteredEventHandler : INotificationHandler<DomainEventNotification<RegisteredEvent>>
    {
        private readonly IIdentityService _identityService;
        private readonly ILogger<RegisteredEventHandler> _logger;
        private readonly IEmailSender _emailSender;

        public RegisteredEventHandler(ILogger<RegisteredEventHandler> logger, IIdentityService identityService, IEmailSender emailSender)
        {
            _logger = logger;
            _identityService = identityService;
            _emailSender = emailSender;
        }

        public async Task Handle(DomainEventNotification<RegisteredEvent> notification, CancellationToken cancellationToken)
        {
            RegisteredEvent domainEvent = notification.DomainEvent;
            string code = await _identityService.GenerateEmailConfirmationTokenAsync(domainEvent.UserId);

            string link = $"http://194.5.236.155/api/account/confirm-email?email{domainEvent.Email}&token={code}";

            await _emailSender.SendEmailAsync($"{domainEvent.Email}", "Hesap Aktivasyonu", $" <a href=\"{link}\">Onay için tıklayınız.</a>");
            _logger.LogInformation("DrumSpace Domain Event: {DomainEvent}", domainEvent.GetType().Name);
        }
    }
}