using System.Collections.Generic;
using Core.Entities.Abstract;
using Core.Entities.Concrete;

#nullable disable

namespace ApartmentManagement.Entities.Models
{
    public class Occupant : BaseEntity, IDeletable
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string IdentityNumber { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsCarOwner { get; set; } = false;
        public string CarPlate { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ChatGroup ChatGroup { get; set; }
        public virtual List<Apartment> Apartments { get; set; }
    }
}
