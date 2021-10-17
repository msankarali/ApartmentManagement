using System.Collections.Generic;
using ApartmentManagement.Entities.Dtos.Occupant;
using Core.Utilities.Results;

namespace ApartmentManagement.Business.Business.Abstract
{
    public interface IOccupantService
    {
        IResult Add(AddOccupantDto addOccupantDto);
    }
}