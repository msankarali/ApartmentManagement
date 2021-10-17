using System;
using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.Entities.Dtos.Invoice;
using FluentValidation;

namespace ApartmentManagement.Business.EntityValidator.Invoice
{
    public class AddInvoiceDtoValidator : AbstractValidator<AddInvoiceDto>
    {
        public AddInvoiceDtoValidator(IInvoiceTypeDal invoiceTypeDal)
        {
            RuleFor(x => x.ApartmentIds)
                .NotEmpty();
            RuleFor(x => x.AmountPayable).GreaterThan(0);
            RuleFor(x => x.DueDate).GreaterThan(DateTime.Now);
            RuleFor(x => x.InvoiceTypeId)
                .NotEmpty()
                .Must(x => invoiceTypeDal.Any(it => it.Id == x));
        }
    }
}