using System;
using Core.Entities.Abstract;

namespace ApartmentManagement.Entities.Dtos.Invoice
{
    public class GetInvoiceDetailDto : IDto
    {
        public int Id { get; set; }
        public string InvoiceTypeName { get; set; }
        public decimal AmountPayable { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsPaid { get; set; }
        public string ApartmentName { get; set; }
        public string Owner { get; set; }
    }
}