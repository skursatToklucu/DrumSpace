using MediatR;

namespace DrumSpace.Application.Accounts.Commands.ConfirmEmail
{
    public class ConfirmCommand : IRequest<bool>
    {
        public string Email { get; set; }
        public string Token { get; set; }
    }
}