using System.Collections.Generic;
using Core.Entities.Abstract;
using Core.Entities.Concrete;

#nullable disable

namespace ApartmentManagement.Entities.Models
{
    public class Apartment : BaseEntity, IDeletable
    {
        public int Id { get; set; }
        public string Door { get; set; }
        public string Floor { get; set; }
        public string Block { get; set; }
        public bool IsAvailable { get; set; }
        public string Type { get; set; }
        public bool? IsOwner { get; set; }
        public int? OccupantId { get; set; }
        public bool IsDeleted { get; set; } = false;

        public virtual Occupant Occupant { get; set; }
        public virtual List<Invoice> Invoices { get; set; }
    }
}
