using Imi.Project.Api.Core.Entities;
using System.Collections.Generic;

namespace Imi.Project.Api.Core.Services.Models;

public class ViewUsersResult : ViewResultsBase
{
    public IEnumerable<User> Users { get; set; }
}
