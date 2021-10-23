using System.Collections.Generic;
using ApartmentManagement.Business.Business.Abstract;
using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.Entities.Dtos.Manager;
using ApartmentManagement.Entities.Models;
using Core.Utilities.Results;
using Mapster;

namespace ApartmentManagement.Business.Business.Concrete
{
    public class ManagerManager : IManagerService
    {
        private readonly IManagerDal _managerDal;

        public ManagerManager(IManagerDal managerDal)
        {
            _managerDal = managerDal;
        }

        public IDataResult<List<GetManagerDto>> GetManagers()
            => new DataResult<List<GetManagerDto>>(ResultType.Success, _managerDal.GetAll().Adapt<List<GetManagerDto>>());
    }
}