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

            var match = _userService.GetSingleUser(x =>
                CheckSexuality(currentUser, x) &&
                x.Age <= 2 * currentUser.Age - 14 &&
                x.Age >= currentUser.Age / 2 + 7);

            if (match is null)
                    return NotFound("No users matching your profile");
                
            var response = new MatchResponse(match.FirstName, match.LastName, match.Sex, match.Sexuality, match.Age,
                match.BirthDay);

            return Ok(response);
        }
        [HttpGet("find-matches")]
        public IActionResult FindMatches(int limit = 5)
        {
            if (limit < 1 || limit > 15) return BadRequest("Limit cannot be more than 15 and less than 1");
            var currentUser = (User) HttpContext.Items["User"];
            
            var matches = _userService.GetUsers(x =>
                CheckSexuality(currentUser, x) &&
                x.Age <= 2 * currentUser.Age - 14 &&
                x.Age >= currentUser.Age / 2 + 7)
                .Select(x => new MatchResponse(x.FirstName, x.LastName, x.Sex, x.Sexuality, x.Age, x.BirthDay));
            
            return Ok(matches);
        }

        private bool CheckSexuality(User currentUser, User matchUser)
        {
            var matchUserBisexualOrPansexual = matchUser.Sexuality == "Bisexual" || matchUser.Sexuality == "Pansexual";

            if ((currentUser.Sexuality == "Heterosexual" ||
                matchUserBisexualOrPansexual || matchUser.Sexuality == "Heterosexual") && matchUser.Sex != currentUser.Sex)
                return true;
            
            if (currentUser.Sexuality == "Bisexual" || currentUser.Sexuality == "Pansexual" && (matchUserBisexualOrPansexual || matchUser.Sexuality == "Heterosexual" && currentUser.Sex != matchUser.Sex))
                return true;
            
            if (currentUser.Sexuality == "Homosexual" && matchUser.Sexuality == "Homosexual" || matchUserBisexualOrPansexual &&
                currentUser.Sex == matchUser.Sex)
                return true;
            return false;
        }
    }
}