using System;
using System.Linq;
using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.DataAccess.Concrete.EntityFramework.Contexts;
using ApartmentManagement.Entities.Dtos.Invoice;
using ApartmentManagement.Entities.Models;
using Core.DataAccess.EntityFramework;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace ApartmentManagement.DataAccess.Concrete.EntityFramework
{
    public class EfInvoiceDal : EfEntityRepositoryBase<Invoice>, IInvoiceDal
    {
        private readonly ApartmentManagementDbContext _dbContext;

        public EfInvoiceDal(ApartmentManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddInvoices(AddInvoiceDto addInvoiceDto)
        {
            var strategy = _dbContext.Database.CreateExecutionStrategy();
            var strategyResult = strategy.Execute(() =>
            {
                using var transaction = _dbContext.Database.BeginTransaction();
                try
                {
                    foreach (var apartmentId in addInvoiceDto.ApartmentIds)
                    {
                        var invoiceToAdd = addInvoiceDto.Adapt<Invoice>();
                        invoiceToAdd.ApartmentId = apartmentId;
                        _dbContext.Invoices.Add(invoiceToAdd);
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return false;
                }
            });
            return strategyResult;
        }
    }
}