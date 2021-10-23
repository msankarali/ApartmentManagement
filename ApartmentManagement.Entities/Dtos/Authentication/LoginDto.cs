using System.ComponentModel.DataAnnotations;
using Core.Entities.Abstract;

namespace ApartmentManagement.Entities.Dtos.Authentication
{
    public class LoginDto : IDto
    {
        [MinLength(4, ErrorMessage = "E-posta en az dört karakterden oluşmalı")]
        [Required(ErrorMessage = "E-posta alanı zorunlu")]
        public string Email { get; set; }
        [MinLength(3, ErrorMessage = "Parola en az üç karakterden oluşmalı")]
        [Required(ErrorMessage = "Parola alanı zorunlu")]
        public string Password { get; set; }
    }
}