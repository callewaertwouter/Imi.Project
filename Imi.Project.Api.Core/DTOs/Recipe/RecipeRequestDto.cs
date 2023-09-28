using Imi.Project.Api.Core.DTOs.Ingredient;
using System;
using System.Collections.Generic;

namespace Imi.Project.Api.Core.DTOs.Recipe;

public class RecipeRequestDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public ICollection<IngredientRequestDto> ListOfIngredients { get; set; }
}
