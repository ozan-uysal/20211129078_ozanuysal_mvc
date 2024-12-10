using Microsoft.AspNetCore.Identity;

namespace Mvc_20211129078_ozanUysal.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        //public string PhotoUrl { get; set; }
    }
}
