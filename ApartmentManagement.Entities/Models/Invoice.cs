using System;
using Core.Entities.Abstract;
using Core.Entities.Concrete;

#nullable disable

namespace ApartmentManagement.Entities.Models
{
    public class Invoice : BaseEntity
    {
        public int Id { get; set; }
        public int InvoiceTypeId { get; set; }
        public decimal AmountPayable { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsPaid { get; set; } = false;
        public int ApartmentId { get; set; }

        public virtual Apartment Apartment { get; set; }
        public virtual InvoiceType InvoiceType { get; set; }
    }
}
