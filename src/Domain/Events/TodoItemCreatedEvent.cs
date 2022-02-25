using DrumSpace.Domain.Common;
using DrumSpace.Domain.Entities;

namespace DrumSpace.Domain.Events
{
    public class TodoItemCreatedEvent : DomainEvent
    {
        private TodoItem Item { get; }

        public TodoItemCreatedEvent(TodoItem item)
        {
            Item = item;
        }
    }
}