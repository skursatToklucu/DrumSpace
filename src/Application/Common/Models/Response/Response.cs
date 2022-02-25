using System.Collections.Generic;
using System.Linq;
using DrumSpace.Application.Common.Interfaces.Response;

namespace DrumSpace.Application.Common.Models.Response
{
    public class Response : IResponse
    {
        public string Message { get; set; }
        public bool DidError => ErrorMessages.Any();
        public List<string> ErrorMessages { get; set; } = new();
    }
}