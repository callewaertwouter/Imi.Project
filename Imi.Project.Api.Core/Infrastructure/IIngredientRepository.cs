using Imi.Project.Api.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Infrastructure;

public interface IIngredientRepository : IBaseRepository<Ingredient>
{
    Task<IEnumerable<Ingredient>> SearchAsync(string search);
}
