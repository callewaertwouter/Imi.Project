using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Infrastructure;

public interface IBaseRepository<T> where T : class
{
    IQueryable<T> GetAll();

    Task<IEnumerable<T>> ListAllAsync();

    Task<T> GetByIdAsync(Guid id);

    Task<T> UpdateAsync(T entity);

    Task<T> AddAsync(T entity);

    Task<T> DeleteAsync(T entity);
}
