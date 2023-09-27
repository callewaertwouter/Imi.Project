using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Imi.Project.Api.Core.Entities;

public class User : IdentityUser
{
    public bool HasApprovedTermsAndConditions { get; set; }
    public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}
