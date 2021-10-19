using ApartmentManagement.Entities.Dtos.Apartment;
using FluentValidation;

namespace ApartmentManagement.Business.EntityValidator.Apartment
{
    public class AddApartmentDtoValidator : AbstractValidator<AddApartmentDto>
    {
        public AddApartmentDtoValidator()
        {
            RuleFor(x => x.Block)
                .MinimumLength(1)
                .MaximumLength(50);
            RuleFor(x => x.Door)
                .MinimumLength(1)
                .MaximumLength(50);
            RuleFor(x => x.Floor)
                .MinimumLength(1)
                .MaximumLength(100);
            RuleFor(x => x.Type)
                .MinimumLength(1)
                .MaximumLength(50);
        }
    }
}