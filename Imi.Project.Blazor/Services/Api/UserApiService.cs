using Imi.Project.Api.Core.DTOs.User;
using Imi.Project.Blazor.Models.Api;
using Imi.Project.Blazor.Services.Crud;

namespace Imi.Project.Blazor.Services.Api;

public class UserApiService : ICRUDService<User>
{
    private string baseUrl = "https://localhost:5001/api/users";
    private readonly HttpClient _httpClient;

    //HttpClient client = new HttpClient();

    public UserApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;

        //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "Token");

        //var response = client.GetAsync(baseUrl);
    }

    public async Task<User> Get(Guid id)
    {
        var dto = await _httpClient.GetFromJsonAsync<UserRequestDto>($"{baseUrl}/{id}");

        if (dto != null)
        {
            return new User
            {
                Id = dto.Id.ToString(),
                Email = dto.Email
            };
        }
        else
        {
            return new User();
        }
    }

    public async Task<IQueryable<User>> GetAll()
    {
        var dtos = await _httpClient.GetFromJsonAsync<UserRequestDto[]>($"{baseUrl}");

        if (dtos != null)
        {
            return dtos.Select(dto => new User
            {
                Id = dto.Id.ToString(),
                Email = dto.Email
            }).AsQueryable();
        }
        else
        {
            return new List<User>().AsQueryable();
        }
    }

    public Task Create(User item)
    {
        var dto = new UserRequestDto
        {
            Id = Guid.NewGuid(),
            Email = item.Email
        };

        return _httpClient.PostAsJsonAsync($"{baseUrl}", dto);
    }

    public Task Update(User item)
    {
        var dto = new UserRequestDto
        {
            Email = item.Email
        };

        return _httpClient.PutAsJsonAsync($"{baseUrl}/{item.Id}", dto);
    }

    public Task Delete(Guid id)
    {
        return _httpClient.DeleteAsync($"{baseUrl}/{id}");
    }
}
