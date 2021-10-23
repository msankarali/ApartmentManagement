using System.Collections.Generic;
using ApartmentManagement.Entities.Dtos.Invoice;
using Core.Utilities.PagedList;
using Core.Utilities.Results;

namespace ApartmentManagement.Business.Business.Abstract
{
    public interface IInvoiceService
    {
        IResult AddInvoices(AddInvoiceDto addInvoiceDto);
        IDataResult<IPagedList<GetInvoiceDetailDto>> GetInvoiceDetails(int pageNumber = 0);
        IDataResult<IPagedList<GetInvoiceDetailDto>> GetOccupantInvoiceDetails(int pageNumber = 0);
    }
}