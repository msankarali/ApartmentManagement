using ApartmentManagement.Business.Business.Abstract;
using ApartmentManagement.DataAccess.Abstract;

namespace ApartmentManagement.Business.Business.Concrete
{
    public class ManagerManager : IManagerService
    {
        private readonly IManagerDal _managerDal;

        public ManagerManager(IManagerDal managerDal)
        {
            _managerDal = managerDal;
        }
    }
}