using System.Collections.Generic;
using ApartmentManagement.Entities.Dtos.Manager;
using Core.Utilities.Results;

namespace ApartmentManagement.Business.Business.Abstract
{
    public interface IManagerService
    {
        IDataResult<List<GetManagerDto>> GetManagers();
    }
}