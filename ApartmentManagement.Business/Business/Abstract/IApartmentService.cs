using ApartmentManagement.Entities.Dtos.Apartment;
using Core.Utilities.Results;

namespace ApartmentManagement.Business.Business.Abstract
{
    public interface IApartmentService
    {
        IResult Add(AddApartmentDto addApartmentDto);
    }
}