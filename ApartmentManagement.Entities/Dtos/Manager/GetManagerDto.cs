using Core.Entities.Abstract;

namespace ApartmentManagement.Entities.Dtos.Manager
{
    public class GetManagerDto : IDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }
}