using Core.Entities.Abstract;

namespace ApartmentManagement.Entities.Dtos.Authentication
{
    public class LoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}