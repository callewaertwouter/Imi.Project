using Imi.Project.Api.Core.DTOs.User;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Imi.Project.Api.Schemas;

public class SwaggerUserLoginSchema : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.Type == typeof(LoginUserRequestDto))
        {
            schema.Type = "object";
            schema.Properties["email"].Example = new OpenApiString($"admin@imi.be");
            schema.Properties["password"].Example = new OpenApiString($"Test123?");
        }
    }
}