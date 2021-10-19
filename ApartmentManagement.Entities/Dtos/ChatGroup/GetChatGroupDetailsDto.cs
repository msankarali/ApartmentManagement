using Core.Entities.Abstract;

namespace ApartmentManagement.Entities.Dtos.ChatGroup
{
    public class GetChatGroupDetailsDto : IDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }
}