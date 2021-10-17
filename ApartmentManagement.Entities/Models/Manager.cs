using Core.Entities.Abstract;
using Core.Entities.Concrete;

#nullable disable

namespace ApartmentManagement.Entities.Models
{
    public class Manager : BaseEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public byte[] PasswordHash { get; set; }

        public virtual ChatGroup ChatGroup { get; set; }
    }
}
