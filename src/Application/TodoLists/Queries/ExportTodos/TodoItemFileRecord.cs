using SourcefulTask.Application.Common.Mappings;
using SourcefulTask.Domain.Entities;

namespace SourcefulTask.Application.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
