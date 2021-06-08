using System;
using System.ComponentModel.DataAnnotations;

namespace CommonAttribute
{
    public class PositiveNumber : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int number = Convert.ToInt32(value);
            if (number < 0)
            {
                return new ValidationResult("Le nombre est négatif");
            }
            return ValidationResult.Success;
        }
    }
}
