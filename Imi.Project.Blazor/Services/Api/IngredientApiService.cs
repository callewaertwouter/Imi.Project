using Imi.Project.Api.Core.DTOs.Ingredient;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Blazor.Services.Crud;

namespace Imi.Project.Blazor.Services.Api;

public class IngredientApiService : ICRUDService<Ingredient>
{
    private string baseUrl = "https://localhost:5001/api/ingredients";
    private readonly HttpClient _httpClient;

    public IngredientApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Ingredient> Get(Guid id)
    {
        var dto = await _httpClient.GetFromJsonAsync<IngredientRequestDto>($"{baseUrl}/{id}");

        if (dto != null)
        {
            return new Ingredient
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }
        else
        {
            return new Ingredient();
        }

    }

    public async Task<IQueryable<Ingredient>> GetAll()
    {
        var dtos = await _httpClient.GetFromJsonAsync<IngredientRequestDto[]>($"{baseUrl}");

        if (dtos != null)
        {
            return dtos.Select(dto => new Ingredient
            {
                Id = dto.Id,
                Name = dto.Name
            }).AsQueryable();
        }
        else
        {
            return Enumerable.Empty<Ingredient>().AsQueryable();
        }
    }

    public Task Create(Ingredient item)
    {
        var dto = new IngredientRequestDto
        {
            Id = Guid.NewGuid(),
            Name = item.Name
        };

        return _httpClient.PostAsJsonAsync($"{baseUrl}", dto);
    }

    //TODO: Figure out why ingredients aren't updating.
    /*
     This functions works properly but on the IngredientsApi.razor page once the code reaches RefreshIngredients, it goes back to the old name.
     */
    public Task Update(Ingredient item)
    {
        var dto = new IngredientRequestDto
        {
            Name = item.Name
        };

        return _httpClient.PutAsJsonAsync($"{baseUrl}/{item.Id}", dto);
    }

    public Task Delete(Guid id)
    {
        return _httpClient.DeleteAsync($"{baseUrl}/{id}");
    }
}
