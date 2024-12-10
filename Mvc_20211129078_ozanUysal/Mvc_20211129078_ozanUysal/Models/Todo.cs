namespace Mvc_20211129078_ozanUysal.Models
{
    public class Todo:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int IsOK { get; set; }
    }
}
