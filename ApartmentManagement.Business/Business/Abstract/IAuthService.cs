using System;
using System.Collections.Generic;
using System.Text;
using ApartmentManagement.Entities.Dtos.Authentication;
using ApartmentManagement.Entities.Models;
using Core.Utilities.Results;

namespace ApartmentManagement.Business.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<Occupant> Login(LoginDto loginDto);
    }
}
