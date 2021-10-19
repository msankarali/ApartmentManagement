using Core.Entities.Abstract;

namespace ApartmentManagement.Entities.Dtos.Occupant
{
    public class GetOccupantDto : IDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string IdentityNumber { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsCarOwner { get; set; } = false;
        public string CarPlate { get; set; }
        public bool IsDeleted { get; set; }
    }
}