using System.Text.Json.Serialization;
using LovePursuerAPI.EF.Models;

namespace LovePursuerAPI.Models
{
    public class AuthenticateResponse
    {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get;  }
        public string Username { get;  }
        public string JwtToken { get; }
        
        [JsonIgnore]
        public string RefreshToken { get; }

        public AuthenticateResponse(User user, string jwtToken, string refreshToken)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Username = user.Username;
            JwtToken = jwtToken;
            RefreshToken = refreshToken;
        }
    }
}