using Core.Entities.Abstract;

namespace ApartmentManagement.Entities.Dtos.Occupant
{
    public class AssignOccupantDto : IDto
    {
        public int OccupantId { get; set; }
        public int ApartmentId { get; set; }
        public bool IsOwner { get; set; }
    }
}