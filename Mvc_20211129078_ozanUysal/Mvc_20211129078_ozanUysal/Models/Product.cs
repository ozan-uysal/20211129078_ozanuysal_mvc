using System.ComponentModel.DataAnnotations;

namespace Mvc_20211129078_ozanUysal.Models
{
    public class Product : BaseEntity
    {

        public string Name { get; set; }
        public string Description { get; set; }
        //public string PhotoUrl { get; set; }
        public float Price { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
