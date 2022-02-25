using DrumSpace.Application.Common.Exceptions;
using FluentAssertions;
using FluentValidation.Results;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using DrumSpace.Application.Common.Models.Response;

namespace DrumSpace.Application.UnitTests.Common.Exceptions
{
    public class ValidationExceptionTests
    {
        [Test]
        public void DefaultConstructorCreatesAnEmptyErrorDictionary()
        {
            Response actual = new ValidationException().Response;

            actual.Should().BeEquivalentTo(Array.Empty<string>());
        }

        [Test]
        public void SingleValidationFailureCreatesASingleElementErrorDictionary()
        {
            List<ValidationFailure> failures = new()
            {
                new ValidationFailure("Age", "must be over 18"),
            };

            Response actual = new ValidationException(failures).Response;

            actual.Should().BeEquivalentTo("Age");
            actual.Should().BeEquivalentTo("must be over 18");
        }

        [Test]
        public void MulitpleValidationFailureForMultiplePropertiesCreatesAMultipleElementErrorDictionaryEachWithMultipleValues()
        {
            List<ValidationFailure> failures = new()
            {
                new ValidationFailure("Age", "must be 18 or older"),
                new ValidationFailure("Age", "must be 25 or younger"),
                new ValidationFailure("Password", "must contain at least 8 characters"),
                new ValidationFailure("Password", "must contain a digit"),
                new ValidationFailure("Password", "must contain upper case letter"),
                new ValidationFailure("Password", "must contain lower case letter"),
            };

            Response actual = new ValidationException(failures).Response;

            actual.Should().BeEquivalentTo(new[] { "Password", "Age" });

            actual.Should().BeEquivalentTo(new[]
            {
                "must be 25 or younger",
                "must be 18 or older",
            });

            actual.Should().BeEquivalentTo(new[]
            {
                "must contain lower case letter",
                "must contain upper case letter",
                "must contain at least 8 characters",
                "must contain a digit",
            });
        }
    }
}