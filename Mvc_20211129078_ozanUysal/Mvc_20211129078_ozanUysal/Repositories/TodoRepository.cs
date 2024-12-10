using Mvc_20211129078_ozanUysal.Models;

namespace Mvc_20211129078_ozanUysal.Repositories
{
    public class TodoRepository : GenericRepository<Todo>
    {
        public TodoRepository(AppDbContext context) : base(context)
        {
        }
    }
}
