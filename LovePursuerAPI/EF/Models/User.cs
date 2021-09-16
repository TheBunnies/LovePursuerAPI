using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LovePursuerAPI.EF.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        [StringLength(69)]
        public string Email { get; set; }
        
        [StringLength(7)]
        public string Sex { get; set; }
        
        public Role Role { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; }

        [JsonIgnore]
        public List<RefreshToken> RefreshTokens { get; set; }
    }

    public enum Role
    {
        User,
        Admin,
        Premium
    }
}