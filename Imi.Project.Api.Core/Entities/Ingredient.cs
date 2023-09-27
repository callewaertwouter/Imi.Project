using System;
using System.Collections.Generic;

namespace Imi.Project.Api.Core.Entities;

public class Ingredient
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public double Quantity { get; set; } = 0;
    public string MeasureUnit { get; set; } = "<geen>";

    public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}
