﻿using Imi.Project.Api.Core.DTOs.Ingredient;
using Imi.Project.Api.Core.DTOs.Recipe;
using Imi.Project.Api.Core.DTOs.User;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Imi.Project.Api.Controllers;

[Authorize]
[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class RecipesController : ControllerBase
{
    protected readonly IRecipeRepository _recipeRepository;
    protected readonly IIngredientRepository _ingredientRepository;

    public RecipesController(IRecipeRepository recipeRepository, 
                             IIngredientRepository ingredientRepository)
    {
        _recipeRepository = recipeRepository;
        _ingredientRepository = ingredientRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var recipes = await _recipeRepository.ListAllAsync();
        var recipesDto = recipes.Select(r => new RecipeResponseDto
        {
            Id = r.Id,
            Title = r.Title,
            Description = r.Description,
            MadeByUser = new ControllerUserResponseDto
            {
                // In case a recipe gets added without a user logged in, this won't cause an error
                Email = r.User != null ? r.User.Email : null,
            },
            Ingredients = r.Ingredients.Select(i => new ControllerIngredientResponseDto
            {
                Name = i.Name,
                Quantity = i.Quantity,
                MeasureUnit = i.MeasureUnit
            }).ToList()
        });

        return Ok((object)recipesDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var recipe = await _recipeRepository.GetByIdAsync(id);

        if (recipe == null) return NotFound($"No recipe with an id of {id}.");

        var recipeDto = new RecipeResponseDto
        {
            Id = recipe.Id,
            Title = recipe.Title,
            Description = recipe.Description,
            Ingredients = recipe.Ingredients.Select(i => new ControllerIngredientResponseDto
            {
                Name= i.Name,
                Quantity = i.Quantity,
                MeasureUnit = i.MeasureUnit
            }).ToList(),
            MadeByUser = new ControllerUserResponseDto
            {
                Email = recipe.User.Email
            }
        };

        return Ok(recipeDto);
    }

    [HttpPost]
    public async Task<IActionResult> Add(RecipeRequestDto recipeDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.Values);
        }

        var recipeEntity = new Recipe
        {
            Title = recipeDto.Title,
            Description = recipeDto.Description
        };

        var associatedIngredients = new List<Ingredient>();

        if (recipeDto.ListOfIngredients != null && recipeDto.ListOfIngredients.Any())
        {
            foreach (var ingredientDto in recipeDto.ListOfIngredients)
            {
                var existingIngredient = await _ingredientRepository.GetByNameAsync(ingredientDto.Name);

                if (existingIngredient != null)
                {
                    associatedIngredients.Add(existingIngredient);
                }
                else
                {
                    var newIngredient = new Ingredient
                    {
                        Name = ingredientDto.Name,
                        Quantity = ingredientDto.Quantity,
                        MeasureUnit = ingredientDto.MeasureUnit,
                    };

                    await _ingredientRepository.AddAsync(newIngredient);
                    associatedIngredients.Add(newIngredient);
                }
            }
        }

        recipeEntity.Ingredients = associatedIngredients;
        await _recipeRepository.AddAsync(recipeEntity);

        return Ok("Recipe added successfully.");
    }


    [HttpPut]
    public async Task<IActionResult> Update(RecipeRequestDto recipeDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.Values);
        }

        var recipeEntity = await _recipeRepository.GetByIdAsync(recipeDto.Id);

        if (recipeEntity == null)
        {
            return NotFound($"No recipe with an id of {recipeDto.Id}");
        }

        recipeEntity.Title = recipeDto.Title;
        recipeEntity.Description = recipeDto.Description;

        // Update the ingedrients
        recipeEntity.Ingredients = recipeDto.ListOfIngredients.Select(i => new Ingredient
        {
            Name = i.Name
        }).ToList();

        await _recipeRepository.UpdateAsync(recipeEntity);

        return Ok("Recipe updated sucessfully.");
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var recipeEntity = await _recipeRepository.GetByIdAsync(id);

        if (recipeEntity == null)
        {
            return NotFound($"No recipe with an id of {id}");
        }

        await _recipeRepository.DeleteAsync(recipeEntity);

        return Ok("Recipe deleted sucessfully.");
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] string searchQuery)
    {
        var searchResults = await _recipeRepository.SearchAsync(searchQuery);

        var searchResultsDto = searchResults.Select(s => new RecipeResponseDto
        {
            Id = s.Id,
            Title = s.Title,
            Description = s.Description,
            Ingredients = s.Ingredients.Select(i => new ControllerIngredientResponseDto
            {
                Name = i.Name,
                Quantity = i.Quantity,
                MeasureUnit = i.MeasureUnit
            }).ToList(),
            MadeByUser = new ControllerUserResponseDto
            {
                Email = s.User?.Email
            }
        });

        return Ok(searchResultsDto);
    }
}