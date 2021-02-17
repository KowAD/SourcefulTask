using SourcefulTask.Application.TodoLists.Queries.ExportTodos;
using System.Collections.Generic;

namespace SourcefulTask.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}
