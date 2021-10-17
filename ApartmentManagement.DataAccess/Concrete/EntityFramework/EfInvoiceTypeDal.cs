using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.DataAccess.Concrete.EntityFramework.Contexts;
using ApartmentManagement.Entities.Models;
using Core.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace ApartmentManagement.DataAccess.Concrete.EntityFramework
{
    public class EfInvoiceTypeDal : EfEntityRepositoryBase<InvoiceType>, IInvoiceTypeDal
    {
        private readonly ApartmentManagementDbContext _dbContext;

        public EfInvoiceTypeDal(ApartmentManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}