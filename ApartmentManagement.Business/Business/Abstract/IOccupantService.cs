using System.Collections.Generic;
using ApartmentManagement.Entities.Dtos.Occupant;
using Core.Utilities.Results;

namespace ApartmentManagement.Business.Business.Abstract
{
    public interface IOccupantService
    {
        IDataResult<AddOccupantResultDto> Add(AddOccupantDto addOccupantDto);
        IDataResult<List<GetOccupantDto>> GetAll();
        IResult UpdateOccupant(UpdateOccupantDto updateOccupantDto);
        IResult DeleteOccupantById(int id);
    }
}