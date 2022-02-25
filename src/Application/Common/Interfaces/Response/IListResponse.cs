using System.Collections.Generic;

namespace DrumSpace.Application.Common.Interfaces.Response
{
    public interface IListResponse<TData> : IResponse
    {
        IEnumerable<TData> Data { get; set; }
    }
}