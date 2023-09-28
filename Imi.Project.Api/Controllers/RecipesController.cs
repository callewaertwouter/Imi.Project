using Imi.Project.Api.Core.DTOs.Ingredient;
using Imi.Project.Api.Core.DTOs.Recipe;
using Imi.Project.Api.Core.DTOs.User;
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

    public RecipesController(IRecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
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
                Email = r.User.Email
            },
            Ingredients = r.Ingredients.Select(i => new ControllerIngredientResponseDto
            {
                Name = i.Name,
                Quantity = i.Quantity,
                MeasureUnit = i.MeasureUnit
            }).ToList()
        });

        return Ok(recipesDto);
    }
}