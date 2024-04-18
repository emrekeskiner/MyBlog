using System.ComponentModel.DataAnnotations;

namespace MyBlog.PresentationLayer.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Lütfen adınızı giriniz.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Lütfen Soyadınızı giriniz.")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Lütfen mail adresinizi giriniz.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Lütfen şifrenizi giriniz.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen Şifreyi Tekrar Girin")]
        [Compare("Password", ErrorMessage = "Şifreler uyumlu değil !")]
        public string ConfirmPassword { get; set; }
    }
}
