using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Api.Core.Services.Models;

public class ViewResultsBase
{
    protected IEnumerable<ValidationResult> _validationResults;

    /// <summary>
    /// Holds all validation errors in this result
    /// </summary>
    public IEnumerable<ValidationResult> ValidationResults { get; set; } = new ValidationResult[0];

    /// <summary>
    /// Gets or sets a value whether this result represents a succesful action
    /// </summary>
    public bool IsSuccess { get; set; }
}
