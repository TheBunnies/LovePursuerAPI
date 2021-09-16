using System.Text.Json.Serialization;
using LovePursuerAPI.EF.Models;

namespace LovePursuerAPI.Models
{
    public class AuthenticateResponse
    {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get;  }

        public string Email { get; }
        public string Sex { get;  }
        public Role Role { get; }
        public string JwtToken { get; }
        
        [JsonIgnore]
        public string RefreshToken { get; }

        public AuthenticateResponse(User user, string jwtToken, string refreshToken)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            Sex = user.Sex;
            Role = user.Role;
            JwtToken = jwtToken;
            RefreshToken = refreshToken;
        }
    }
}