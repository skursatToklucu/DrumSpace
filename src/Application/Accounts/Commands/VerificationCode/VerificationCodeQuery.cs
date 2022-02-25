using MediatR;

namespace DrumSpace.Application.Accounts.Commands.VerificationCode
{
    public class VerificationCodeQuery : IRequest<bool>
    {
        public int VerificationCode { get; set; }
    }
}