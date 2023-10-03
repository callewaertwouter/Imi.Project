using System;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Api.Core.DTOs.Ingredient;

public class IngredientRequestDto
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "{0} is een verplicht veld!")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Minstens 2 karakters voor de naam.")]
    public string Name { get; set; }
    public double Quantity { get; set; }
    public string MeasureUnit { get; set; }
}
