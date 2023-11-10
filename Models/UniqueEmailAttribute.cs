using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RegisterAndLogin.Models
{
    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Email is required");
            }

            LoginContext? _context = (validationContext?.GetService(typeof(LoginContext)) as LoginContext);

            if (_context?.Users.Any(u => u.Email == value.ToString()) == true)
            {
                return new ValidationResult("Email is already in use");
            }
            else 
            {
                return ValidationResult.Success;
            }
        }
    }
}