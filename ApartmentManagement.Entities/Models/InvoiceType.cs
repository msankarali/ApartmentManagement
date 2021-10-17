using System.Collections.Generic;
using Core.Entities.Abstract;
using Core.Entities.Concrete;

#nullable disable

namespace ApartmentManagement.Entities.Models
{
    public class InvoiceType : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Invoice> Invoices { get; set; }
    }
}
