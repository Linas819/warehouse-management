using Microsoft.AspNetCore.Mvc;
using warehouse_management.Services;
using warehouse_management.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace warehouse_management.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private UserService userService;
    public UserController(UserService userService)
    {
        this.userService = userService;
    }
    [AllowAnonymous]
    [HttpPost]
    public IActionResult LogIn([FromBody] LoginUser user)
    {
        user = userService.Login(user);
        return(Ok(new{
            Login = user.Login,
            UserId = user.UserId,
            Token = user.Token
        }));
    }
    [HttpGet]
    public IActionResult GetLoginToken()
    {
        string userId = User.FindFirst(ClaimTypes.SerialNumber)?.Value!;
        LoginUser loginUser = userService.LoginToken(userId);
        return(Ok(new{
            Login = loginUser.Login,
            UserId = loginUser.UserId,
            Token = loginUser.Token
        }));
    }

}