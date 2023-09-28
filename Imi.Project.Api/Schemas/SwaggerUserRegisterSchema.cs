using Imi.Project.Api.Core.DTOs.Ingredient;
using Imi.Project.Api.Core.DTOs.User;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Imi.Project.Api.Schemas;

public class SwaggerUserRegisterSchema : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        Random random = new Random();
        var randomNumber = random.Next(0, 1000);

        if (context.Type == typeof(RegisterUserRequestDto))
        {
            schema.Type = "object";
            schema.Properties["email"].Example = new OpenApiString($"test{randomNumber}@imi.be");
            schema.Properties["userName"].Example = new OpenApiString("");
            schema.Properties["password"].Example = new OpenApiString($"Test123?");
            schema.Properties["confirmPassword"].Example = new OpenApiString($"Test123?");
        }
    }
}
