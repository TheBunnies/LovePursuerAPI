using System.ComponentModel.DataAnnotations;

namespace LovePursuerAPI.Models
{
    public class AuthenticateRequest
    {
        [Required]
        public string Email { get; }
        
        [Required]
        public string Password { get; }
        
        public AuthenticateRequest(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}