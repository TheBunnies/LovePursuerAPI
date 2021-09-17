using System.ComponentModel.DataAnnotations;
using LovePursuerAPI.Validation;

namespace LovePursuerAPI.Models
{
    public class RegisterRequest
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Sex]
        [StringLength(12)]
        public string Sex { get; set; }
        [Required]
        [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,}$")]
        public string Password { get; set; }
    }
}