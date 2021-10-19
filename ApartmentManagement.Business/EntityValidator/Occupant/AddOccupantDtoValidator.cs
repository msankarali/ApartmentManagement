using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.Entities.Dtos.Occupant;
using FluentValidation;

namespace ApartmentManagement.Business.EntityValidator.Occupant
{
    public class AddOccupantDtoValidator : AbstractValidator<AddOccupantDto>
    {
        public AddOccupantDtoValidator(IOccupantDal occupantDal)
        {
            RuleFor(x => x.FullName)
                .Must(x => occupantDal.Any(o => o.FullName != x)).WithMessage("Bu isimle daha önce hesap açılmış!")
                .MinimumLength(2)
                .MaximumLength(100);
            RuleFor(x => x.Mail)
                .Must(x => occupantDal.Any(o => o.Mail != x)).WithMessage("Bu mail hesabı kullanımda!")
                .EmailAddress();
            RuleFor(x => x.IdentityNumber)
                .Must(x => occupantDal.Any(o => o.IdentityNumber != x)).WithMessage("Bu kimlik numarası kullanımda!");
            When(x => x.IsCarOwner, () =>
            {
                RuleFor(x => x.CarPlate)
                    .Must(x => occupantDal.Any(o => o.CarPlate != x))
                    .MinimumLength(3)
                    .MaximumLength(30);
            });
        }
    }
}