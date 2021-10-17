using System.Collections.Generic;
using Core.Entities.Abstract;
using Core.Entities.Concrete;

#nullable disable

namespace ApartmentManagement.Entities.Models
{
    public class ChatGroup : BaseEntity
    {
        public int Id { get; set; }
        public int OccupantId { get; set; }
        public int ManagerId { get; set; }

        public virtual Manager Manager { get; set; }
        public virtual Occupant Occupant { get; set; }
        public virtual List<Message> Messages { get; set; }
    }
}
