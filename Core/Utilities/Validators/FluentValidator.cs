using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;

namespace Core.Utilities.Validators
{
    public class FluentValidator
    {
        public static (bool hasError, List<string> errors) Validate<TValidator, TEntity>(TValidator validator, TEntity entity)
        {
            var entityValidator = (AbstractValidator<TEntity>)Activator.CreateInstance(entity.GetType());
            var result = entityValidator.Validate(entity);
            return (result.IsValid, result.Errors.Select(e => e.ErrorMessage).ToList());
        }
    }
}