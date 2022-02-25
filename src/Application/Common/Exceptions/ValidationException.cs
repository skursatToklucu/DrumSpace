using System;
using System.Collections.Generic;
using System.Linq;
using DrumSpace.Application.Common.Models.Response;
using FluentValidation.Results;

namespace DrumSpace.Application.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public Response Response { get; } 

        public ValidationException() : base("One or more validation failures have occurred.")
        {
            Response = new Response();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            failures.ToList().ForEach(c => Response.ErrorMessages.Add(c.ErrorMessage));

            /*Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());*/
        }
    }
}