using System;
using System.ComponentModel.DataAnnotations;

namespace LovePursuerAPI.Validation
{
    public class SexualityAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (value is not string str)
                return new ValidationResult("Sexuality is not a string or empty");

            switch (str)
            {
                case "Heterosexual":
                    return ValidationResult.Success;
                case "Homosexual":
                    return ValidationResult.Success;
                case "Bisexual":
                    return ValidationResult.Success;
                case "Pansexual":
                    return ValidationResult.Success;
                default:
                    return new ValidationResult("Unknown sexuality type");
            }
            
        }
    }
}