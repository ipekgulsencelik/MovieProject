using System.ComponentModel.DataAnnotations;

namespace Movie.Application.Features.CQRS.Commands.UserRegisterCommands
{
    public class CreateUserRegisterCommand
    {
        [Required(ErrorMessage = "Adınızı giriniz.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyadınızı giriniz.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Kullanıcı adınızı giriniz.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "E-posta adresinizi giriniz.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifrenizi giriniz.")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        public string Password { get; set; }
    }
}