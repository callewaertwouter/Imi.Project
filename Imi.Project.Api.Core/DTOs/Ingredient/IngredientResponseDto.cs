using Imi.Project.Api.Core.DTOs.Recipe;
using System;
using System.Collections.Generic;

namespace Imi.Project.Api.Core.DTOs.Ingredient;

public class IngredientResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public double Quantity { get; set; }
    public string MeasureUnit { get; set; }
    public ICollection<RecipeResponseDto> UsedInRecipes { get; set; }
}
