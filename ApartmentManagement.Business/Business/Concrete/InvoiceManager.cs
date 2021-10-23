using System.Linq;
using ApartmentManagement.Business.Business.Abstract;
using ApartmentManagement.Business.EntityValidator.Invoice;
using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.Entities.Dtos.Invoice;
using ApartmentManagement.Entities.Models;
using Core.Utilities.IoC;
using Core.Utilities.PagedList;
using Core.Utilities.Results;
using Core.Utilities.UserManagement;
using Core.Utilities.Validators;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace ApartmentManagement.Business.Business.Concrete
{
    public class InvoiceManager : IInvoiceService
    {
        private readonly IInvoiceDal _invoiceDal;

        public InvoiceManager(IInvoiceDal invoiceDal)
        {
            _invoiceDal = invoiceDal;
        }

        public IResult AddInvoices(AddInvoiceDto addInvoiceDto)
        {
            var entityValidator = new AddInvoiceDtoValidator(
                ServiceTool.GetService<IInvoiceTypeDal>()
                ).ValidateEntity(addInvoiceDto);
            if (entityValidator.hasError)
                return new Result(ResultType.Error)
                    .AddMessage(entityValidator.errors);

            var isOperationSuccessful = _invoiceDal.AddInvoices(addInvoiceDto);

            return isOperationSuccessful is true
                ? new Result(ResultType.Success).AddMessage($"Fatura{(addInvoiceDto.ApartmentIds.Length > 1 ? "lar" : "")} oluşturuldu.")
                : new Result(ResultType.Error).AddMessage("Fatura oluşturma işlemi sırasında bir hata oluştu!");
        }

        public IDataResult<IPagedList<GetInvoiceDetailDto>> GetInvoiceDetails(int pageNumber)
        {
            return new DataResult<IPagedList<GetInvoiceDetailDto>>(ResultType.Success, _invoiceDal.GetAllPagedSelect(
                    selector: i => new GetInvoiceDetailDto
                    {
                        Id = i.Id,
                        AmountPayable = i.AmountPayable,
                        DueDate = i.DueDate,
                        ApartmentName = $"Blok: {i.Apartment.Block}, Kat: {i.Apartment.Floor}, Kapı: {i.Apartment.Door}",
                        InvoiceTypeName = i.InvoiceType.Name,
                        IsPaid = i.IsPaid,
                        Owner = i.Apartment.Occupant.FullName
                    },
                    predicate: i => i.Apartment.OccupantId == CurrentUser.Id,
                    orderBy: iq => iq.OrderByDescending(i => i.DueDate),
                    enableTracking: false,
                    include: iq => iq
                        .Include(i => i.Apartment)
                            .ThenInclude(a => a.Occupant)
                        .Include(i => i.InvoiceType),
                    pageNumber: pageNumber,
                    pageSize: 5
                ));
        }

        public IDataResult<IPagedList<GetInvoiceDetailDto>> GetOccupantInvoiceDetails(int pageNumber = 0)
        {
            return new DataResult<IPagedList<GetInvoiceDetailDto>>(ResultType.Success, _invoiceDal.GetAllPagedSelect(
                selector: i => new GetInvoiceDetailDto
                {
                    Id = i.Id,
                    AmountPayable = i.AmountPayable,
                    DueDate = i.DueDate,
                    ApartmentName = $"Blok: {i.Apartment.Block}, Kat: {i.Apartment.Floor}, Kapı: {i.Apartment.Door}",
                    InvoiceTypeName = i.InvoiceType.Name,
                    IsPaid = i.IsPaid,
                    Owner = i.Apartment.Occupant.FullName
                },
                predicate: i => i.Apartment.OccupantId == CurrentUser.Id,
                orderBy: iq => iq.OrderByDescending(i => i.DueDate),
                enableTracking: false,
                include: iq => iq
                    .Include(i => i.Apartment)
                    .ThenInclude(a => a.Occupant)
                    .Include(i => i.InvoiceType),
                pageNumber: pageNumber,
                pageSize: 10
            ));
        }
    }
}