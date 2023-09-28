using Imi.Project.Api.Core.DTOs.Ingredient;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Imi.Project.Api.Schemas;

public class SwaggerIngredientSchema : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        Random random = new Random();
        var randomNumber = random.Next(0, 1000);

        if (context.Type == typeof(IngredientRequestDto))
        {
            schema.Type = "object";
            schema.Properties["name"].Example = new OpenApiString("TestIngredient" + randomNumber); 
        }
    }
}
