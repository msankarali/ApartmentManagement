using System;
using Core.Entities.Abstract;

namespace ApartmentManagement.Entities.Dtos.Message
{
    public class GetMessageDto : IDto
    {
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}