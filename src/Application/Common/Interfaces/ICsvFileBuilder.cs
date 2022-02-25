using DrumSpace.Application.TodoLists.Queries.ExportTodos;
using System.Collections.Generic;

namespace DrumSpace.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}