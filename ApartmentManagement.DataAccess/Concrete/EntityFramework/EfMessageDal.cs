using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.DataAccess.Concrete.EntityFramework.Contexts;
using ApartmentManagement.Entities.Models;
using Core.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace ApartmentManagement.DataAccess.Concrete.EntityFramework
{
    public class EfMessageDal : EfEntityRepositoryBase<Message>, IMessageDal
    {
        private readonly ApartmentManagementDbContext _dbContext;

        public EfMessageDal(ApartmentManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}