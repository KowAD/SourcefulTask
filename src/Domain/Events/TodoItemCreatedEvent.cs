using SourcefulTask.Domain.Common;
using SourcefulTask.Domain.Entities;

namespace SourcefulTask.Domain.Events
{
    public class TodoItemCreatedEvent : DomainEvent
    {
        public TodoItemCreatedEvent(TodoItem item)
        {
            Item = item;
        }

        public TodoItem Item { get; }
    }
}
