using ApartmentManagement.Entities.Dtos.Apartment;
using FluentValidation;

namespace ApartmentManagement.Business.EntityValidator.Apartment
{
    public class UpdateApartmentDtoValidator : AbstractValidator<UpdateApartmentDto>
    {
        public UpdateApartmentDtoValidator()
        {
            RuleFor(x => x.Block).MinimumLength(1);
            RuleFor(x => x.Door).MinimumLength(1);
            RuleFor(x => x.Floor).MinimumLength(1);
            RuleFor(x => x.Type).MinimumLength(1);
        }
    }
}