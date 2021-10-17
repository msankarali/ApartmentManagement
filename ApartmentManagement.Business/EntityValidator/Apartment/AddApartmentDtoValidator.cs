using ApartmentManagement.Entities.Dtos.Apartment;
using FluentValidation;

namespace ApartmentManagement.Business.EntityValidator.Apartment
{
    public class AddApartmentDtoValidator : AbstractValidator<AddApartmentDto>
    {
        public AddApartmentDtoValidator()
        {
            RuleFor(a => a.Block)
                .MinimumLength(1)
                .MaximumLength(50);
        }
    }
}