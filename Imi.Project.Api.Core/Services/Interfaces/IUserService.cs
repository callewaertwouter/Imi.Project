using Imi.Project.Api.Core.Services.Models;
using System.Threading.Tasks;
using System;

namespace Imi.Project.Api.Core.Services.Interfaces;

public interface IUserService
{
    Task<ViewUsersResult> GetAllUsers();
    Task<ViewUsersResult> GetUserById(Guid id);
    Task<ViewUsersResult> SearchUserByName(string searchInput);
}
