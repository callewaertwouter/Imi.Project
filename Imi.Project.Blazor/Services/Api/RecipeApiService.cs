using Imi.Project.Api.Core.DTOs.Ingredient;
using Imi.Project.Api.Core.DTOs.Recipe;
using Imi.Project.Api.Core.DTOs.User;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Blazor.Services.Crud;

namespace Imi.Project.Blazor.Services.Api;

public class RecipeApiService : ICRUDService<Recipe>
{
    private string baseUrl = "https://localhost:5001/api/recipes";
    private readonly HttpClient _httpClient;

    public RecipeApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Recipe> Get(Guid id)
    {
        var dto = await _httpClient.GetFromJsonAsync<RecipeRequestDto>($"{baseUrl}/{id}");

        if (dto != null)
        {
            return new Recipe
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                Ingredients = dto.ListOfIngredients.Select(i => new Ingredient
                {
                    Name = i.Name,
                    Quantity = i.Quantity,
                    MeasureUnit = i.MeasureUnit
                }).ToList()
            };
        }

        return new Recipe(); //TODO: Improve this.
    }

    public async Task<IQueryable<Recipe>> GetAll()
    {
        var dtos = await _httpClient.GetFromJsonAsync<RecipeRequestDto[]>($"{baseUrl}");

        if (dtos != null)
        {
            return dtos.Select(dto => new Recipe
            {
                Id = dto.Id,
                Title = dto.Title ?? "<TitleNotFound>", 
                Description = dto.Description ?? "<DescriptionNotFound>",
                Ingredients = dto.ListOfIngredients?.Select(i => new Ingredient
                {
                    Name = i?.Name ?? "<IngredientNotFound>",
                    Quantity = i?.Quantity ?? 0,
                    MeasureUnit = i?.MeasureUnit ?? ""
                }).ToList() ?? new List<Ingredient>()
            }).AsQueryable();
        }
        else
        {
            return new List<Recipe>().AsQueryable();
        }

        //TODO: Probably can show just Title...
    }

    public Task Create(Recipe item)
    {
        var dto = new RecipeRequestDto
        {
            Id = Guid.NewGuid(),
            Title = item.Title,
            Description = item.Description,
            ListOfIngredients = item.Ingredients.Select(i => new IngredientRequestDto
            {
                Name= i.Name,
                Quantity = i.Quantity,
                MeasureUnit = i.MeasureUnit
            }).ToList(),
            CreatedByUser = new UserRequestDto
            {
                Id = Guid.Parse(item.UserId),
                Email = item.User?.Email
            }
        };

        return _httpClient.PostAsJsonAsync($"{baseUrl}", dto);
    }

    public Task Update(Recipe item)
    {
        var dto = new RecipeRequestDto
        {
            Title = item.Title,
            Description = item.Description,
            ListOfIngredients = item.Ingredients.Select(i => new IngredientRequestDto
            {
                Name = i.Name,
                Quantity = i.Quantity,
                MeasureUnit = i.MeasureUnit
            }).ToList()
        };

        return _httpClient.PutAsJsonAsync($"{baseUrl}/{item.Id}", dto);
    }

    public Task Delete(Guid id)
    {
        return _httpClient.DeleteAsync($"{baseUrl}/{id}");
    }
}
