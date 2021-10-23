using System.Collections.Generic;
using ApartmentManagement.Entities.Dtos.Apartment;
using ApartmentManagement.Entities.Dtos.Occupant;
using ApartmentManagement.Entities.Models;
using Core.Utilities.Results;

namespace ApartmentManagement.Business.Business.Abstract
{
    public interface IApartmentService
    {
        IResult Add(AddApartmentDto addApartmentDto);
        IResult Update(UpdateApartmentDto updateApartmentDto);
        IResult AssignOccupant(AssignOccupantDto assignOccupantDto);
        IDataResult<List<Apartment>> GetAll();
        Apartment GetById(int apartmentId);
        IDataResult<List<GetApartmentDetailDto>> GetAllOwnedApartments();
        IResult SwitchDeleteById(int apartmentId);
    }
}