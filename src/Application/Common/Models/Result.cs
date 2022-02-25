using System.Collections.Generic;
using System.Linq;

namespace DrumSpace.Application.Common.Models
{
    public class Result
    {
        public bool Succeeded { get; }

        public string[] Errors { get; }

        private Result(bool succeeded, IEnumerable<string> errors)
        {
            Succeeded = succeeded;
            Errors = errors.ToArray();
        }

        public static Result Success() => new(true, System.Array.Empty<string>());
        public static Result Failure(IEnumerable<string> errors) => new(false, errors);
    }
}