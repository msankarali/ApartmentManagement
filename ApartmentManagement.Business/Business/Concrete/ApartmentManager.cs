using ApartmentManagement.Business.Business.Abstract;
using ApartmentManagement.Business.EntityValidator.Apartment;
using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.Entities.Dtos.Apartment;
using ApartmentManagement.Entities.Models;
using Core.Utilities.Results;
using Core.Utilities.Validators;
using Mapster;

namespace ApartmentManagement.Business.Business.Concrete
{
    public class ApartmentManager : IApartmentService
    {
        private readonly IApartmentDal _apartmentDal;

        public ApartmentManager(IApartmentDal apartmentDal)
        {
            _apartmentDal = apartmentDal;
        }

        public IResult Add(AddApartmentDto addApartmentDto)
        {
            var entityValidation = FluentValidator.Validate(typeof(AddApartmentDtoValidator), addApartmentDto);
            if (entityValidation.hasError)
                return new Result(ResultType.Error)
                    .AddMessage(entityValidation.errors);

            _apartmentDal.Add(addApartmentDto.Adapt<Apartment>());

            return new Result(ResultType.Success)
                .AddMessage("Daire bilgisi eklendi");
        }
    }
}