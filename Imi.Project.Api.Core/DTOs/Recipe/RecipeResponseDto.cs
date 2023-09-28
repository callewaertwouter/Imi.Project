﻿using Imi.Project.Api.Core.DTOs.Ingredient;
using Imi.Project.Api.Core.DTOs.User;
using System;
using System.Collections.Generic;

namespace Imi.Project.Api.Core.DTOs.Recipe;

public class RecipeResponseDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public ICollection<ControllerIngredientResponseDto> Ingredients { get; set; }
    public ControllerUserResponseDto MadeByUser { get; set; }
}
