using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Infrastructure;
using Imi.Project.Api.Core.Services.Interfaces;
using Imi.Project.Api.Core.Services.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace Imi.Project.Api.Core.Services;

public class RecipeService : IRecipeService
{
    private readonly IRecipeRepository _recipeRepository;

    public RecipeService(IRecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }

    public async Task<ViewRecipesResult> GetAllRecipes()
    {
        var result = new ViewRecipesResult();
        result.ValidationResults = new List<ValidationResult>();

        result.Recipes = await _recipeRepository.ListAllAsync();
        result.IsSuccess = true;

        return result;
    }

    public async Task<ViewRecipesResult> GetRecipeById(Guid id)
    {
        var result = new ViewRecipesResult();
        var validationResults = new List<ValidationResult>();

        var recipe = await _recipeRepository.GetByIdAsync(id);

        if (recipe == null)
        {
            validationResults.Add(new ValidationResult($"Recipe with id {id} is not found."));
            result.IsSuccess = false;
        }
        else
        {
            var recipeIngredients = result.Recipes.Select(x => x.Ingredients).ToList();
            if (recipeIngredients == null)
            {
                validationResults.Add(new ValidationResult($"Ingedrients not found for this recipe."));
                result.IsSuccess = false;
            }
            else
            {
                var recipes = new List<Recipe>();
                recipes.Add(recipe);

                result.Recipes = recipes;
                result.IsSuccess = true;
            }
        }

        result.ValidationResults = validationResults;

        return result;
    }

    public async Task<ViewRecipesResult> SearchRecipeByName(string searchInput)
    {
        var result = new ViewRecipesResult();
        var validationResults = new List<ValidationResult>();

        if (string.IsNullOrWhiteSpace(searchInput))
        {
            validationResults.Add(new ValidationResult($"Zoekveld niet ingevuld!"));
            result.IsSuccess = false;
        }
        else if (searchInput.Length <= 1)
        {
            validationResults.Add(new ValidationResult($"Ten minste 2 karakters zijn vereist om te zoeken naar recepten."));
            result.IsSuccess = false;
        }
        else
        {
            var recipes = await _recipeRepository.SearchAsync(searchInput);
            result.Recipes = recipes;
            result.IsSuccess = true;
        }

        result.ValidationResults = validationResults;
        return result;
    }
}
