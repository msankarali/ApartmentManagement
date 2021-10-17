using ApartmentManagement.Entities.Dtos.Invoice;
using ApartmentManagement.Entities.Models;
using Core.DataAccess.EntityFramework;

namespace ApartmentManagement.DataAccess.Abstract
{
    public interface IInvoiceDal : IEntityRepository<Invoice>
    {
        bool AddInvoices(AddInvoiceDto addInvoiceDto);
    }
}