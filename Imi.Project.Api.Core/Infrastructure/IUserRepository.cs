using Imi.Project.Api.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Infrastructure;

public interface IUserRepository : IBaseRepository<User>
{
    Task<IEnumerable<User>> SearchAsync(string search);
}
