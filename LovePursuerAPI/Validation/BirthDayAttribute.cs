using System;
using System.ComponentModel.DataAnnotations;

namespace LovePursuerAPI.Validation
{
    public class BirthDayAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var bday = (DateTime) value;
            if (bday == DateTime.MinValue) return new ValidationResult("Birthday is required");
            
            var age = DateTime.Today.Year - bday.Year;
            if (bday.Date > DateTime.Today.AddYears(-age)) age--;
            
            if (age < 18) return new ValidationResult("User cannot be underage");
            
            return ValidationResult.Success;
        }
    }
}