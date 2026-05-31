using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace mvc.Models
{
    public class Contact
    {
        [NumericOnly] 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    public class NumericOnly : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (value == null) return ValidationResult.Success;

            if (!Regex.IsMatch(value.ToString(), @"^\d+$"))
                return new ValidationResult("Id must be numeric");

            return ValidationResult.Success;
        }
    }
}