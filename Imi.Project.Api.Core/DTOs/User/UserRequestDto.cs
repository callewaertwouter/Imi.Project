using System;

namespace Imi.Project.Api.Core.DTOs.User;

public class UserRequestDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }
}
