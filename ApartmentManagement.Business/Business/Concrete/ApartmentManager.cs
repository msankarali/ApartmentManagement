using System.Collections.Generic;
using System.Linq;
using ApartmentManagement.Business.Business.Abstract;
using ApartmentManagement.Business.EntityValidator.Apartment;
using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.Entities.Dtos.Apartment;
using ApartmentManagement.Entities.Dtos.Occupant;
using ApartmentManagement.Entities.Models;
using Core.Utilities.IoC;
using Core.Utilities.Results;
using Core.Utilities.UserManagement;
using Core.Utilities.Validators;
using Mapster;
using Microsoft.EntityFrameworkCore;

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
            var entityValidation = new AddApartmentDtoValidator().ValidateEntity(addApartmentDto);
            if (entityValidation.hasError)
                return new Result(ResultType.Error)
                    .AddMessage(entityValidation.errors);

            _apartmentDal.Add(addApartmentDto.Adapt<Apartment>());

            return new Result(ResultType.Success)
                .AddMessage("Daire bilgisi eklendi");
        }

        public IResult Update(UpdateApartmentDto updateApartmentDto)
        {
            var entityValidation = new UpdateApartmentDtoValidator().ValidateEntity(updateApartmentDto);
            if (entityValidation.hasError)
                return new Result(ResultType.Error)
                    .AddMessage(entityValidation.errors);

            var apartmentToUpdate = _apartmentDal.GetFirst(
                predicate: a => a.Id == updateApartmentDto.Id,
                ignoreQueryFilters: true);
            updateApartmentDto.Adapt(apartmentToUpdate);

            _apartmentDal.Update(apartmentToUpdate);

            return new Result(ResultType.Success)
                .AddMessage("Daire bilgisi güncellendi");
        }

        public IResult AssignOccupant(AssignOccupantDto assignOccupantDto)
        {
            var entityValidation = new AssignOccupantDtoValidator(
                ServiceTool.GetService<IOccupantDal>(),
                ServiceTool.GetService<IApartmentDal>()
                ).ValidateEntity(assignOccupantDto);
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
            new DataResult<List<Apartment>>(ResultType.Success, _apartmentDal.GetAll(
                ignoreQueryFilters: true,
                include: aq => aq.Include(a => a.Occupant))
            );

        public Apartment GetById(int apartmentId)
        {
            return _apartmentDal.GetFirst(
                predicate: a => a.Id == apartmentId,
                ignoreQueryFilters: true);
        }

        public IDataResult<List<GetApartmentDetailDto>> GetAllOwnedApartments()
        {
            return new DataResult<List<GetApartmentDetailDto>>(ResultType.Success,
                _apartmentDal
                    .GetAll(
                        predicate: a => a.OccupantId == CurrentUser.Id,
                        orderBy: aq => aq.OrderByDescending(a => a.Id))
                    .Adapt<List<GetApartmentDetailDto>>());
        }

        public IResult SwitchDeleteById(int apartmentId)
        {
            var apartmentToUpdate = _apartmentDal.GetFirst(
                predicate: a => a.Id == apartmentId,
                ignoreQueryFilters: true);
            apartmentToUpdate.IsDeleted = !apartmentToUpdate.IsDeleted;

            _apartmentDal.Update(apartmentToUpdate);

            return new Result(ResultType.Success)
                .AddMessage(apartmentToUpdate.IsDeleted
                    ? "Apartman başarıyla silindi"
                    : "Apartman geri alma işlemi başarılı")
                .WithCode(apartmentToUpdate.IsDeleted
                    ? 1
                    : 0);
        }
    }
}