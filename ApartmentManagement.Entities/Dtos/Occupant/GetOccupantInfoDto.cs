using Core.Entities.Abstract;

namespace ApartmentManagement.Entities.Dtos.Occupant
{
    public class GetOccupantInfoDto : IDto
    {
        public string FullName { get; set; }
        public string IdentityNumber { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsCarOwner { get; set; }
        public string CarPlate { get; set; }
    }
}