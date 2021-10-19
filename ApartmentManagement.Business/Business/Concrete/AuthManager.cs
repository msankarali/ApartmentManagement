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

        public AuthManager(IOccupantDal occupantDal)
        {
            _occupantDal = occupantDal;
        }
        public IDataResult<Occupant> Login(LoginDto loginDto)
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
    }
}