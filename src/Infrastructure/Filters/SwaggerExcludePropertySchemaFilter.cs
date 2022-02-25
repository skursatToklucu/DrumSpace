using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DrumSpace.Application.Common.Swagger;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DrumSpace.Infrastructure.Filters
{
    public class SwaggerExcludePropertySchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (schema?.Properties == null)
            {
                return;
            }

            IEnumerable<PropertyInfo> excludedProperties = context.Type.GetProperties().Where(t => t.GetCustomAttribute<SwaggerIgnorePropertyAttribute>() != null);

            foreach (PropertyInfo excludedProperty in excludedProperties)
            {
                string propertyToRemove = schema.Properties.Keys.SingleOrDefault(x => string.Equals(x, excludedProperty.Name, StringComparison.OrdinalIgnoreCase));

                if (propertyToRemove != null)
                {
                    schema.Properties.Remove(propertyToRemove);
                }
            }
        }
    }
}