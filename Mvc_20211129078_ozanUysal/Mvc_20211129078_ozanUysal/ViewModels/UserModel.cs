using System.ComponentModel.DataAnnotations;

namespace Mvc_20211129078_ozanUysal.ViewModels
{
    public class UserModel
    {
        public string Id { get; set; }

        [Display(Name = "Name and Surname")]
        [Required(ErrorMessage = "Enter Name and Surname!")]
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


        [Display(Name = "Authority")]
        [Required(ErrorMessage = "Enter Authorization!")]
        public string Role { get; set; }

        //[Display(Name = "Fotoğraf")]
        //public string PhotoUrl { get; set; }
    }
}
