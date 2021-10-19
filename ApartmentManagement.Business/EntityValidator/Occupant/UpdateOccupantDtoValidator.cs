using ApartmentManagement.Entities.Dtos.Occupant;
using FluentValidation;

namespace ApartmentManagement.Business.EntityValidator.Occupant
{
    public class UpdateOccupantDtoValidator : AbstractValidator<UpdateOccupantDto>
    {
        public UpdateOccupantDtoValidator()
        {
            RuleFor(x => x.Mail).EmailAddress();
        }
    }
}