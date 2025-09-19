using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Models;
using MyFirstApi.Prototypes;

namespace MyFirstApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly ProfilePrototypeRegistry _prototypeRegistry;

    public UsersController(ProfilePrototypeRegistry prototypeRegistry)
    {
        _prototypeRegistry = prototypeRegistry;
    }

    [HttpPost("create-from-template")]
    public ActionResult<UserProfile> CreateUserFromTemplate([FromQuery] string userName, [FromQuery] string templateKey = "default")
    {
        UserProfile? newUserProfile = _prototypeRegistry.GetPrototype(templateKey);

        if (newUserProfile is null)
        {
            return NotFound($"Profile template '{templateKey}' not found.");
        }

        newUserProfile.UserName = userName;

        return Ok(newUserProfile.ToString());
    }
}