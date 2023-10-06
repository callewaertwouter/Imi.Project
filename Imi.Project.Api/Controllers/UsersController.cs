using Imi.Project.Api.Core.DTOs.Recipe;
using Imi.Project.Api.Core.DTOs.User;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Imi.Project.Api.Controllers;

[Authorize]
//[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    protected readonly IUserRepository _userRepository;
    protected readonly IRecipeRepository _recipeRepository;
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;
    private readonly SignInManager<User> _signInManager;

    public UsersController(IUserRepository userRepository,
                           IRecipeRepository recipeRepository,
                           IConfiguration configuration,
                           UserManager<User> userManager,
                           SignInManager<User> signInManager)
    {
        _userRepository = userRepository;
        _recipeRepository = recipeRepository;
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserRequestDto registration)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        User newUser = new User
        {
            Email = registration.Email,
            UserName = registration.UserName,
            HasApprovedTermsAndConditions = registration.HasApprovedTermsAndConditions
        };

        IdentityResult result = await _userManager.CreateAsync(newUser, registration.Password);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            return BadRequest(ModelState);
        }

        newUser = await _userManager.FindByEmailAsync(registration.Email);
        await _userManager.AddClaimAsync(newUser,
                                         new Claim("registration-date",
                                         DateTime.UtcNow.ToString("yy-MM-dd")));

        await _userManager.AddClaimAsync(newUser,
                                         new Claim("email",
                                         registration.Email));

        return Ok("User successfully registered.");
    }

    [AllowAnonymous]
    [HttpPost("api/auth/login")]
    public async Task<ActionResult> Login([FromBody] LoginUserRequestDto login)
    {
        var userName = await _userManager.FindByEmailAsync(login.Email);

        var result = await _signInManager.PasswordSignInAsync(
            userName != null ? userName.UserName : login.Email,
            login.Password,
            isPersistent: false,
            lockoutOnFailure: false
        );

        if (!result.Succeeded) return Unauthorized();


        var applicationUser = await _userManager.FindByEmailAsync(login.Email);
        JwtSecurityToken token = await GenerateTokenAsync(applicationUser); //defined
        string serializedToken = new JwtSecurityTokenHandler().WriteToken(token); //serialize the token

        return Ok(new LoginUserResponseDto()
        {
            Token = serializedToken
        });
    }

    private async Task<JwtSecurityToken> GenerateTokenAsync(User user)
    {
        var claims = new List<Claim>();

        // Loading the user Claims
        var userClaims = await _userManager.GetClaimsAsync(user);
        claims.AddRange(userClaims);

        // Loading the roles and put them in a claim of a Role ClaimType
        var roleClaims = await _userManager.GetRolesAsync(user);
        foreach (var roleClaim in roleClaims)
        {
            claims.Add(new Claim(ClaimTypes.Role, roleClaim));
        }

        var expirationDays = _configuration.GetValue<int>("JWTConfiguration:TokenExpirationDays");
        var siginingKey = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWTConfiguration:SigningKey"));
        var token = new JwtSecurityToken(issuer: _configuration.GetValue<string>("JWTConfiguration:Issuer"),
                                           audience: _configuration.GetValue<string>("JWTConfiguration:Audience"),
                                           claims: claims,
                                           expires: DateTime.UtcNow.Add(TimeSpan.FromDays(expirationDays)),
                                           notBefore: DateTime.UtcNow,
                                           signingCredentials: new SigningCredentials(new SymmetricSecurityKey(siginingKey), SecurityAlgorithms.HmacSha256)
                                         );

        return token;
    }

    [AllowAnonymous]
    [HttpGet("api/auth/logout")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();

        return Ok("User successfully logged out.");
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var users = await _userRepository.ListAllAsync();
        var usersDto = users.Select(r => new UserResponseDto
        {
            Id = Guid.Parse(r.Id),
            Email = r.Email,
            HasAcceptedTermsAndConditions = r.HasApprovedTermsAndConditions
        });

        return Ok(usersDto);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        if (user == null)
        {
            return NotFound($"No user with an id of {id}.");
        }

        var userDto = new UserResponseDto
        {
            Id = Guid.Parse(user.Id),
            Email = user.Email,
            HasAcceptedTermsAndConditions = user.HasApprovedTermsAndConditions
        };

        return Ok(userDto);
    }

    // No Add-function because Register-function already does that.

    [HttpPut]
    public async Task<IActionResult> Update(UserRequestDto userDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.Values);
        }

        var userEntity = await _userRepository.GetByIdAsync(userDto.Id);

        if (userEntity == null)
        {
            return NotFound($"No user with an id of {userDto.Id}.");
        }

        userEntity.Email = userDto.Email;

        await _userRepository.UpdateAsync(userEntity);

        return Ok("User successfully updated.");
    }

    [Authorize(Roles = "Admin")] // I see deleting as a form of "banning" someone so for now only Admins can do this
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var userEntity = await _userRepository.GetByIdAsync(id);

        if (userEntity == null)
        {
            return NotFound($"No user with an id of {id}.");
        }

        await _userRepository.DeleteAsync(userEntity);

        return Ok("User successfully deleted. Farewell!");
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] string searchQuery)
    {
        var searchResults = await _userRepository.SearchAsync(searchQuery);

        var searchResultsDto = searchResults.Select(s => new UserResponseDto
        {
            Id = Guid.Parse(s.Id),
            Email = s.Email,
            HasAcceptedTermsAndConditions = s.HasApprovedTermsAndConditions,
            Recipes = s.Recipes?.Select(r => new ControllerRecipeResponseDto
            {
                Title = r.Title
            }).ToList()
        });

        return Ok(searchResultsDto);
    }
}