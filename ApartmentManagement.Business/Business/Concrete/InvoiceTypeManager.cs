using ApartmentManagement.Business.Business.Abstract;
using ApartmentManagement.DataAccess.Abstract;

namespace ApartmentManagement.Business.Business.Concrete
{
    public class InvoiceTypeManager : IInvoiceTypeService
    {
        private readonly IInvoiceDal _invoiceDal;

        public InvoiceTypeManager(IInvoiceDal invoiceDal)
        {
            _invoiceDal = invoiceDal;
        }
    }
}