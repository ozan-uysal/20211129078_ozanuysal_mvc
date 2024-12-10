using System.ComponentModel.DataAnnotations;

namespace Mvc_20211129078_ozanUysal.ViewModels
{
    public class BaseModel
    {
        public int Id { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
