using Imi.Project.Api.Core.Entities;
using System.Collections.Generic;

namespace Imi.Project.Api.Core.Services.Models;

public class ViewRecipesResult : ViewResultsBase
{
    public IEnumerable<Recipe> Recipes { get; set; }
}
