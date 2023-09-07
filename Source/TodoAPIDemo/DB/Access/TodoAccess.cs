using TodoAPIDemo.DB.Entitys;
using ToDoAPIDemo.DB;

namespace TodoAPIDemo.DB.Access
{
    public class TodoAccess
    {
        protected readonly DataContext _context;

        public TodoAccess(DataContext context)
        {
            _context = context;
        }

        public List<Todo> Get()
        {
            return _context.Todos.ToList();
        }

        public int GetNextId()
        {
            return _context.Todos.Max(p => p.Id) + 1;
        }

        public void Insert(Todo todo)
        {
            _context.Add(todo);
            _context.SaveChanges();
        }

        public void Update(Todo todo)
        {
            var td = _context.Todos.Where(p => p.Id == todo.Id).FirstOrDefault();

            if (td == null)
            {
                return;
            }

            td.Content = todo.Content;
            td.Name = todo.Name;
            td.IsComplete = todo.IsComplete;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var td = _context.Todos.Where(p => p.Id == id).FirstOrDefault();

            if (td == null)
            {
                return;
            }

            _context.Todos.Remove(td);
            _context.SaveChanges();
        }
    }
}
