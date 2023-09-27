﻿using Imi.Project.Api.Core.DTOs.Recipe;
using System;
using System.Collections.Generic;

namespace Imi.Project.Api.Core.DTOs.User;

public class UserResponseDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool HasAcceptedTermsAndConditions { get; set; }
    public ICollection<RecipeResponseDto> CreatedRecipes { get; set; }
}
