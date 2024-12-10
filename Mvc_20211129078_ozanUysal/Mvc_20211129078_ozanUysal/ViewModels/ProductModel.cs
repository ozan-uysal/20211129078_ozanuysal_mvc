using System.ComponentModel.DataAnnotations;

namespace Mvc_20211129078_ozanUysal.ViewModels
{
    public class ProductModel : BaseModel
    {


        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Enter Product Name!")]
        public string Name { get; set; }


        [Display(Name = "Product Description")]
        [Required(ErrorMessage = "Enter Product Description!")]
        public string Description { get; set; }


        [Display(Name = "Product Price")]
        [Required(ErrorMessage = "Enter Product Price!")]
        public decimal Price { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "Enter Category!")]
        public int CategoryId { get; set; }

        //[Display(Name = "Photo File")]
        //public IFormFile PhotoFile { get; set; }

        //[Display(Name = "Photo")]
        //public string PhotoUrl { get; set; }
    }
}
