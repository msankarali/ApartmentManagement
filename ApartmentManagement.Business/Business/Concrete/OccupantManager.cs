using ApartmentManagement.Business.Business.Abstract;
using ApartmentManagement.Business.EntityValidator.Occupant;
using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.Entities.Dtos.Occupant;
using ApartmentManagement.Entities.Models;
using Core.Utilities.Results;
using Core.Utilities.Validators;
using Mapster;

namespace ApartmentManagement.Business.Business.Concrete
{
    public class OccupantManager : IOccupantService
    {
        private readonly IOccupantDal _occupantDal;

        public OccupantManager(IOccupantDal occupantDal)
        {
            _occupantDal = occupantDal;
        }

        public IResult Add(AddOccupantDto addOccupantDto)
        {
            var entityValidation = FluentValidator.Validate(typeof(AddOccupantDtoValidator), addOccupantDto);
            if (entityValidation.hasError)
                return new Result(ResultType.Error)
                    .AddMessage(entityValidation.errors);

            _occupantDal.Add(addOccupantDto.Adapt<Occupant>());

            return new Result(ResultType.Success)
                .AddMessage("Kullanıcı eklendi");
        }
    }
}