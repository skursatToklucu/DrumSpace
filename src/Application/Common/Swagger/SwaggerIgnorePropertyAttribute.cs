using System;

namespace DrumSpace.Application.Common.Swagger
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SwaggerIgnorePropertyAttribute : Attribute
    {
    }
}