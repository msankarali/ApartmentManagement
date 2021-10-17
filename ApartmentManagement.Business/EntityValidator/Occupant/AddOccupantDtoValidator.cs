using ApartmentManagement.Entities.Dtos.Occupant;
using FluentValidation;

namespace ApartmentManagement.Business.EntityValidator.Occupant
{
    public class AddOccupantDtoValidator : AbstractValidator<AddOccupantDto>
    {
        public AddOccupantDtoValidator()
        {
            RuleFor(x => x.FullName)
                .MinimumLength(2)
                .MaximumLength(100);
        }
    }
}