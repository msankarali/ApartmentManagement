using System.Collections.Generic;
using System.Linq;
using ApartmentManagement.Business.Business.Abstract;
using ApartmentManagement.Business.EntityValidator.Apartment;
using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.Entities.Dtos.Apartment;
using ApartmentManagement.Entities.Dtos.Occupant;
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

        public IResult AssignOccupant(AssignOccupantDto assignOccupantDto)
        {
            var entityValidation = FluentValidator.Validate(typeof(AssignOccupantDtoValidator), assignOccupantDto);
            if (entityValidation.hasError)
                return new Result(ResultType.Information)
                    .AddMessage(entityValidation.errors);

            var apartmentToUpdate = _apartmentDal.GetFirst(a => a.Id == assignOccupantDto.ApartmentId);
            apartmentToUpdate.OccupantId = assignOccupantDto.OccupantId;
            apartmentToUpdate.IsOwner = assignOccupantDto.IsOwner;

            _apartmentDal.Update(apartmentToUpdate);
            return new Result(ResultType.Success)
                .AddMessage("Kullanıcı ataması başarılı");
        }

        public IDataResult<List<Apartment>> GetAll() =>
            new DataResult<List<Apartment>>(ResultType.Success, _apartmentDal.GetAll(ignoreQueryFilters: true));

        public IDataResult<List<GetApartmentDetailDto>> GetAllOwnedApartments()
        {
            return new DataResult<List<GetApartmentDetailDto>>(ResultType.Success,
                _apartmentDal
                    .GetAll(orderBy: aq => aq.OrderByDescending(a => a.Id))
                    .Adapt<List<GetApartmentDetailDto>>());
        }
    }
}