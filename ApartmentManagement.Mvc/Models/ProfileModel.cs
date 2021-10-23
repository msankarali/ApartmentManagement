using System.Collections.Generic;
using ApartmentManagement.Entities.Dtos.Apartment;
using ApartmentManagement.Entities.Dtos.Occupant;

namespace ApartmentManagement.Mvc.Models
{
    public class ProfileModel
    {
        public GetOccupantInfoDto OccupantInfo { get; set; }
        public List<GetApartmentDetailDto> OwnedApartments { get; set; }
    }
}