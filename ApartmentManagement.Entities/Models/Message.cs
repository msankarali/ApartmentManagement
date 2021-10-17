using System;
using Core.Entities.Abstract;
using Core.Entities.Concrete;

#nullable disable

namespace ApartmentManagement.Entities.Models
{
    public class Message : BaseEntity
    {
        public int Id { get; set; }
        public int ChatGroupId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        public virtual ChatGroup ChatGroup { get; set; }
    }
}
