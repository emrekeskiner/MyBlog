using System.ComponentModel.DataAnnotations;

namespace MyBlog.PresentationLayer.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı Adını Giriniz..!")]
        public string Username { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifreyi Giriniz..!")]
        public string Password { get; set; }
    }
}
