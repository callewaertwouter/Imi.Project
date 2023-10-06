namespace Imi.Project.Blazor.Models.Api;

public class Recipe : BaseEntity
{
	public string Title { get; set; }
	public string Description { get; set; }
	public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
	public User User { get; set; }
	public string UserId { get; set; }
}
