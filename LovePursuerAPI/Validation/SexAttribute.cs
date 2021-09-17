using System;
using System.ComponentModel.DataAnnotations;

namespace LovePursuerAPI.Validation
{
    public class SexAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (value is not string str)
                throw new ArgumentException("Targeted type should be a string");

            switch (str)
            {
                case "Female":
                    return ValidationResult.Success;
                case "Male":
                    return ValidationResult.Success;
                default:
                    return new ValidationResult("Sex should be either Male or Female");
            }
        }
    }
}