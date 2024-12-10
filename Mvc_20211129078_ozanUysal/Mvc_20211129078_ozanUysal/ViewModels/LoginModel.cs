using System.ComponentModel.DataAnnotations;

namespace Mvc_20211129078_ozanUysal.ViewModels
{
    public class LoginModel
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Input Username")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Input Password!")]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool KeepMe { get; set; }
    }
}
