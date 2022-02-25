using DrumSpace.Domain.Common;

namespace DrumSpace.Domain.Events
{
    public class RegisteredEvent : DomainEvent
    {
        public string UserId { get; }
        public string Email { get; }

        public RegisteredEvent(string userId, string email)
        {
            UserId = userId;
            Email = email;
        }
    }
}