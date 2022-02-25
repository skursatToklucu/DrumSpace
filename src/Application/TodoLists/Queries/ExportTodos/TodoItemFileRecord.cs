using DrumSpace.Application.Common.Mappings;
using DrumSpace.Domain.Entities;

namespace DrumSpace.Application.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}