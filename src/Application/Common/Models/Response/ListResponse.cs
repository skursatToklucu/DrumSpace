using System.Collections.Generic;
using System.Linq;
using DrumSpace.Application.Common.Interfaces.Response;

namespace DrumSpace.Application.Common.Models.Response
{
    public class ListResponse<TData> : IListResponse<TData>
    {
        public string Message { get; set; }
        public bool DidError => ErrorMessages.Any();
        public List<string> ErrorMessages { get; set; } = new();
        public IEnumerable<TData> Data { get; set; }
    }
}