using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebUI.Common.Helpers;

public class DateOnlySchema : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.Type == typeof(DateOnly))
        {
            schema.Example = new OpenApiObject
            {
                ["date"] = new OpenApiString("yyyy-MM-dd"),
            };
        }
    }
}