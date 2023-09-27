using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Infrastructure;
using Imi.Project.Api.Core.Services.Interfaces;
using Imi.Project.Api.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services;

public class IngredientService : IIngredientService
{
    private readonly IIngredientRepository _ingredientRepository;

    public IngredientService(IIngredientRepository ingredientRepository)
    {
        _ingredientRepository = ingredientRepository;
    }

    public async Task<ViewIngredientsResult> GetAllIngedrients()
    {
        var result = new ViewIngredientsResult();
        result.ValidationResults = new List<ValidationResult>();

        result.Ingredients = await _ingredientRepository.ListAllAsync();
        result.IsSuccess = true;

        return result;
    }

    public async Task<ViewIngredientsResult> GetIngedrientById(Guid id)
    {
        var result = new ViewIngredientsResult();
        var validationResults = new List<ValidationResult>();

        var ingredient = await _ingredientRepository.GetByIdAsync(id);

        if (ingredient == null)
        {
            validationResults.Add(new ValidationResult($"Ingredient met id {id} is niet gevonden."));
            result.IsSuccess = false;
        }
        else
        {
            var ingredients = new List<Ingredient>();
            ingredients.Add(ingredient);

            result.Ingredients = ingredients;
            result.IsSuccess = true;
        }

        result.ValidationResults = validationResults;

        return result;
    }

    public async Task<ViewIngredientsResult> SearchIngredientByName(string searchInput)
    {
        var result = new ViewIngredientsResult();
        var validationResults = new List<ValidationResult>();

        if (string.IsNullOrWhiteSpace(searchInput))
        {
            validationResults.Add(new ValidationResult($"Zoekveld niet ingevuld!"));
            result.IsSuccess = false;
        }
        else if (searchInput.Length <= 2)
        {
            validationResults.Add(new ValidationResult($"Ten minste 2 karakters zijn vereist om te zoeken naar ingredienten."));
            result.IsSuccess = false;
        }
        else
        {
            var ingredients = await _ingredientRepository.SearchAsync(searchInput);
            result.Ingredients = ingredients;
            result.IsSuccess = true;
        }

        result.ValidationResults = validationResults;
        return result;
    }
}
