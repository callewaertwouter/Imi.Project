using System;

namespace Imi.Project.Api.Core.DTOs.User;

public class UserResponseDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public bool HasAcceptedTermsAndConditions { get; set; }
}
