using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;

namespace Core.Utilities.Validators
{
    public static class FluentValidator
    {
        public static (bool hasError, List<string> errors) ValidateEntity<T>(this IValidator validator, T instance)
        {
            var result = validator.Validate(new ValidationContext<T>(instance));
            return (!result.IsValid, result.Errors.Select(e => e.ErrorMessage).ToList());
        }
    }
}