using Imi.Project.Api.Core.Entities;
using System.Collections.Generic;

namespace Imi.Project.Api.Core.Services.Models;

public class ViewIngredientsResult : ViewResultsBase
{
    public IEnumerable<Ingredient> Ingredients { get; set; }
}
