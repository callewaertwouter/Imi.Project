namespace Imi.Project.Blazor.Models.Api;

public class Ingredient : BaseEntity
{
    public string Name { get; set; }
    public double Quantity { get; set; } = 0;
    public string MeasureUnit { get; set; } = "<geen>";
}
