using System.Globalization;
using ApartmentManagement.Business.Business.Abstract;
using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.Entities.Dtos.Authentication;
using ApartmentManagement.Entities.Models;
using Core.Utilities.Results;
using Core.Utilities.Security;

namespace ApartmentManagement.Business.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IOccupantDal _occupantDal;
        private readonly IManagerDal _managerDal;

        public AuthManager(IOccupantDal occupantDal, IManagerDal managerDal)
        {
            _occupantDal = occupantDal;
            _managerDal = managerDal;
        }

        public IDataResult<Occupant> UserLogin(LoginDto loginDto)
        {
            var occupant = _occupantDal.GetFirst(o => o.Mail == loginDto.Email);

            if (occupant == null)
                return new DataResult<Occupant>(ResultType.Error)
                    .AddMessage("Kullanıcı bulunamadı");

            if (occupant.IsDeleted)
                return new DataResult<Occupant>(ResultType.Error)
                    .AddMessage("Kullanıcı devre dışı");

            if (HashingHelper.VerifyPasswordHash(loginDto.Password, occupant.PasswordHash, occupant.PasswordSalt))
            {
                return new DataResult<Occupant>(ResultType.Success, occupant)
                    .AddMessage("Giriş başarılı");
            }

            return new DataResult<Occupant>(ResultType.Error)
                .AddMessage("Parola yanlış");
        }

        public IDataResult<Manager> ManagerLogin(LoginDto loginDto)
        {
            var manager = _managerDal.GetFirst(o => o.FullName == loginDto.Email.ToUpper());

            if (manager == null)
                return new DataResult<Manager>(ResultType.Error)
                    .AddMessage("Yönetici bulunamadı");
            
            if (HashingHelper.VerifyPasswordHash(loginDto.Password, manager.PasswordHash, manager.PasswordSalt))
            {
                return new DataResult<Manager>(ResultType.Success, manager)
                    .AddMessage("Giriş başarılı");
            }

            return new DataResult<Manager>(ResultType.Error)
                .AddMessage("Parola yanlış");
        }
    }
}