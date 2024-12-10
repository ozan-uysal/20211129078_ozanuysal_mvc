using AutoMapper;
using Mvc_20211129078_ozanUysal.Models;
using Mvc_20211129078_ozanUysal.ViewModels;

namespace Mvc_20211129078_ozanUysal.Repositories
{
    public class ProductRepository : GenericRepository<Product>
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
    }
}
