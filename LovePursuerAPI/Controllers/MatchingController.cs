using System.Linq;
using LovePursuerAPI.Attributes;
using LovePursuerAPI.EF.Models;
using LovePursuerAPI.Models.Responses;
using LovePursuerAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LovePursuerAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class MatchingController : ControllerBase
    {
        private readonly IUserService _userService;
        public MatchingController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("find-match")]
        public IActionResult FindMatch()
        {
            var currentUser = (User) HttpContext.Items["User"];

            var matches = _userService.GetUsers(x =>
                    x.Sex != currentUser.Sex && x.Sexuality == currentUser.Sexuality &&
                    x.Age <= 2 * currentUser.Age - 14 && x.Age >= currentUser.Age / 2 + 7)
                .Select(x => new MatchResponse(x.FirstName, x.LastName, x.Sex, x.Sexuality, x.Age, x.BirthDay));
            if (!matches.Any())
                    return NotFound("No users matching your profile");
            
            return Ok(matches);
        }
    }
}