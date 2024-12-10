using System.ComponentModel.DataAnnotations;

namespace Mvc_20211129078_ozanUysal.ViewModels
{
    public class RegisterModel
    {
        [Display(Name = "Name and Surname")]
        [Required(ErrorMessage = "Enter name and Surname!")]
        public string FullName { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Enter Username!")]
        public string UserName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Enter Your Email!")]
        public string Email { get; set; }


        [Display(Name = "Password")]
        [Required(ErrorMessage = "Enter Password!")]
        public string Password { get; set; }


        [Display(Name = "Re-enter Password")]
        [Required(ErrorMessage = "Re-enter Password!")]
        public string PasswordConfirm { get; set; }


        //[Display(Name = "Photo")]
        //public IFormFile PhotoFile { get; set; }
    }
}
