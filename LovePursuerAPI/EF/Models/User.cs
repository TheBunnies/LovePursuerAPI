using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using LovePursuerAPI.Validation;

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
        
        [StringLength(69)]
        public string Sexuality {get; set; }
        
        public DateTime BirthDay { get; set; }

        [NotMapped]
        public int Age
        {
            get
            {
                var age = DateTime.Today.Year - BirthDay.Year;
                if (BirthDay.Date > DateTime.Today.AddYears(-age)) age--;
                return age;
            }
            
        }
        
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