using System.Collections.Generic;

namespace DrumSpace.Application.Common.Interfaces.Response
{
    public interface IResponse
    {
        string Message { get; set; }
        bool DidError { get; }
        public List<string> ErrorMessages { get; set; }
    }
}