using DrumSpace.Domain.Common;
using System.Threading.Tasks;

namespace DrumSpace.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}