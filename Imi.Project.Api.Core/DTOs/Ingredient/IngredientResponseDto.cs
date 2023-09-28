using System;

namespace Imi.Project.Api.Core.DTOs.Ingredient;

public class IngredientResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public double Quantity { get; set; }
    public string MeasureUnit { get; set; }
}
