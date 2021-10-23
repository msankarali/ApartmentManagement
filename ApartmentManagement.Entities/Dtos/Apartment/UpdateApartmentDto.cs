using Core.Entities.Abstract;

namespace ApartmentManagement.Entities.Dtos.Apartment
{
    public class UpdateApartmentDto : IDto
    {
        public int Id { get; set; }
        public string Door { get; set; }
        public string Floor { get; set; }
        public string Block { get; set; }
        public bool IsAvailable { get; set; }
        public string Type { get; set; }
    }
}