using SourcefulTask.Domain.Common;
using SourcefulTask.Domain.Entities;

namespace SourcefulTask.Domain.Events
{
    public class TodoItemCompletedEvent : DomainEvent
    {
        public TodoItemCompletedEvent(TodoItem item)
        {
            Item = item;
        }

        public TodoItem Item { get; }
    }
}
