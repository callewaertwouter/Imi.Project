using Imi.Project.Api.Core.Services.Models;
using System.Threading.Tasks;
using System;

namespace Imi.Project.Api.Core.Services.Interfaces;

public interface IRecipeService
{
    Task<ViewRecipesResult> GetAllRecipes();
    Task<ViewRecipesResult> GetRecipeById(Guid id);
    Task<ViewRecipesResult> SearchRecipeByName(string searchInput);
}
