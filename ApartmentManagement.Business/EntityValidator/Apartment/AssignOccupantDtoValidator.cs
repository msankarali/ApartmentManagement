using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.Entities.Dtos.Occupant;
using FluentValidation;

namespace ApartmentManagement.Business.EntityValidator.Apartment
{
    public class AssignOccupantDtoValidator : AbstractValidator<AssignOccupantDto>
    {
        public AssignOccupantDtoValidator(IOccupantDal occupantDal, IApartmentDal apartmentDal)
        {
            RuleFor(x => x.ApartmentId)
                .Must(x => apartmentDal.Any(a => a.Id != x)).WithMessage("Geçersiz atama");
            RuleFor(x => x.OccupantId)
                .Must(x => occupantDal.Any(o => o.Id != x)).WithMessage("Geçersiz atama");
        }
    }
}