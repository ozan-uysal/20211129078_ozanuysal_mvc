using System.ComponentModel.DataAnnotations;

namespace Mvc_20211129078_ozanUysal.ViewModels
{
    public class CategoryModel : BaseModel
    {

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Enter Category Name!")]
        public string Name { get; set; }

    }
}
