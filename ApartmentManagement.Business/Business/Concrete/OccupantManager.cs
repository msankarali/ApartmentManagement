using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using ApartmentManagement.Business.Business.Abstract;
using ApartmentManagement.Business.EntityValidator.Occupant;
using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.Entities.Dtos.Occupant;
using ApartmentManagement.Entities.Models;
using Core.Utilities.Results;
using Core.Utilities.Security;
using Core.Utilities.Validators;
using Mapster;
using MapsterMapper;
using PasswordGenerator;

namespace ApartmentManagement.Business.Business.Concrete
{
    public class OccupantManager : IOccupantService
    {
        private readonly IOccupantDal _occupantDal;

        public OccupantManager(IOccupantDal occupantDal)
        {
            _occupantDal = occupantDal;
        }

        public IDataResult<AddOccupantResultDto> Add(AddOccupantDto addOccupantDto)
        {
            var entityValidation = FluentValidator.Validate(typeof(AddOccupantDtoValidator), addOccupantDto);
            if (entityValidation.hasError)
                return new DataResult<AddOccupantResultDto>(ResultType.Error)
                    .AddMessage(entityValidation.errors);

            var newPassword = new Password(
                includeLowercase: true,
                includeUppercase: false,
                includeNumeric: true,
                includeSpecial: false,
                passwordLength: 6).Next();

            HashingHelper.CreatePasswordHash(newPassword, out var passwordHash, out var passwordSalt);

            var occupantToAdd = addOccupantDto.Adapt<Occupant>();
            occupantToAdd.PasswordHash = passwordHash;
            occupantToAdd.PasswordSalt = passwordSalt;

            _occupantDal.Add(occupantToAdd);

            return new DataResult<AddOccupantResultDto>(ResultType.Success, new AddOccupantResultDto(occupantToAdd.Mail, newPassword))
                .AddMessage("Kullanıcı eklendi")
                .AddMessage("Lütfen bu bilgileri saklayın");
        }

        public IDataResult<List<GetOccupantDto>> GetAll()
        {
            return new DataResult<List<GetOccupantDto>>(ResultType.Success,
                _occupantDal.GetAll(ignoreQueryFilters: true)
                .Adapt<List<GetOccupantDto>>());
        }

        public IResult UpdateOccupant(UpdateOccupantDto updateOccupantDto)
        {
            var entityValidation = FluentValidator.Validate(typeof(UpdateOccupantDtoValidator), updateOccupantDto);
            if (entityValidation.hasError)
                return new Result(ResultType.Error)
                    .AddMessage(entityValidation.errors);

            var occupantToUpdate = _occupantDal.GetFirst(o => o.Id == updateOccupantDto.Id);
            occupantToUpdate.Adapt(updateOccupantDto);
            _occupantDal.Update(occupantToUpdate);

            return new Result(ResultType.Success)
                .AddMessage("Kullanıcı güncellendi");
        }

        public IResult DeleteOccupantById(int id)
        {
            var occupantToUpdate = _occupantDal.GetFirst(o => o.Id == id);
            occupantToUpdate.IsDeleted = true;
            _occupantDal.Update(occupantToUpdate);

            return new Result(ResultType.Success)
                .AddMessage("Kullanıcı silindi");
        }
    }
}