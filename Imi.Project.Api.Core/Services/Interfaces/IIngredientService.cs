using System.Threading.Tasks;
using System;
using Imi.Project.Api.Core.Services.Models;

namespace Imi.Project.Api.Core.Services.Interfaces;

public interface IIngredientService
{
    Task<ViewIngredientsResult> GetAllIngedrients();

    Task<ViewIngredientsResult> GetIngedrientById(Guid id);

    Task<ViewIngredientsResult> SearchIngredientByName(string searchInput);
}
