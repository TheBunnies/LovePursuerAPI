using System;
using System.Threading;
using System.Threading.Tasks;
using LovePursuerAPI.Attributes;
using LovePursuerAPI.EF.Models;
using LovePursuerAPI.Models;
using LovePursuerAPI.Models.Requests;
using LovePursuerAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LovePursuerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequest model, CancellationToken cancellationToken)
        {
            await _userService.RegisterAsync(model, cancellationToken);
            var response = await _userService.AuthenticateAsync(new AuthenticateRequest(model.Email, model.Password), GetIpAddress(), cancellationToken);
            SetTokenCookie(response.RefreshToken);

            return Ok(response);
        }
        
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticateRequest model, CancellationToken cancellationToken)
        {
            var response = await _userService.AuthenticateAsync(model, GetIpAddress(), cancellationToken);
            SetTokenCookie(response.RefreshToken);
            
            return Ok(response);
        }
        
        [AllowAnonymous]
        [HttpPost("refresh-token")]
        // Refresh refresh token and JWT
        public async Task<IActionResult> RefreshTokenAsync(CancellationToken cancellationToken)
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var response = await _userService.RefreshTokenAsync(refreshToken, GetIpAddress(), cancellationToken);
            SetTokenCookie(response.RefreshToken);
            return Ok(response);
        }
        
        [Authorize]
        [HttpPost("revoke-token")]
        // Revoke refresh token
        public async Task<IActionResult> RevokeRefreshTokenAsync(RevokeTokenRequest model, CancellationToken cancellationToken)
        {
            var token = model.Token ?? Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(token))
                return BadRequest(new { message = "Token is required" });

            await _userService.RevokeRefreshTokenAsync(token, GetIpAddress(), cancellationToken);
            return Ok(new { message = "Token revoked" });
        }

        [Authorize]
        [HttpGet("whoami")]
        public IActionResult GetMyself()
        {
            return Ok((User)HttpContext?.Items["User"]);
        }
        

        private void SetTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }

        private string GetIpAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}