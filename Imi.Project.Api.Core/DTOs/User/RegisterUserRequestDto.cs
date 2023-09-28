using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Api.Core.DTOs.User;

public class RegisterUserRequestDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    private string _userName;

    // Sets the part of the Email before the '@' as username if user decides not to fill in a UserName.
    public string UserName
    {
        get
        {
            if (string.IsNullOrEmpty(_userName))
            {
                int atIndex = Email.IndexOf('@');
                if (atIndex >= 0)
                {
                    return Email.Substring(0, atIndex);
                }
                else
                {
                    return string.Empty;
                }
            }

            return _userName;
        }
        set
        {
            _userName = value;
        }
    }

    [Required]
    [StringLength(100, MinimumLength = 6)]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }

    public bool HasApprovedTermsAndConditions { get; set; } = true;
}
