using System;
using Core.Entities.Abstract;

namespace ApartmentManagement.Entities.Dtos.Invoice
{
    public class AddInvoiceDto : IDto
    {
        public int InvoiceTypeId { get; set; }
        public decimal AmountPayable { get; set; }
        public DateTime DueDate { get; set; }
        public int[] ApartmentIds { get; set; }
    }
}