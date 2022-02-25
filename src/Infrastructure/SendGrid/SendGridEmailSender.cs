using System.Threading.Tasks;
using DrumSpace.Application.Common.Interfaces;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace DrumSpace.Infrastructure.SendGrid
{
    public class SendGridEmailSender : IEmailSender
    {
        private readonly SendGridEmailSenderOptions _options;

        public SendGridEmailSender(IOptions<SendGridEmailSenderOptions> options) => _options = options.Value;


        public async Task SendEmailAsync(string email, string subject, string message) =>
            await Execute(subject, message, email);

        private async Task<Response> Execute(string subject, string message, string email)
        {
            var client = new SendGridClient(_options.ApiKey);
            var msg = new SendGridMessage
            {
                From = new EmailAddress(_options.SenderEmail, _options.SenderName),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));

            return await client.SendEmailAsync(msg);
        }
    }
}