using ApartmentManagement.Entities.Models;
using Core.DataAccess.EntityFramework;

namespace ApartmentManagement.DataAccess.Abstract
{
    public interface IManagerDal : IEntityRepository<Manager>
    {
        
    }
}