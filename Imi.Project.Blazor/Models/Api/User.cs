using Microsoft.AspNetCore.Identity;

namespace Imi.Project.Blazor.Models.Api
{
	public class User : IdentityUser
	{
		public bool HasApprovedTermsAndConditions { get; set; }
		public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
	}
}
