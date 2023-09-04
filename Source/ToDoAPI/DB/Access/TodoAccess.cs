using AutoMapper;

namespace ToDoAPI.DB
{
    public class TodoAccess : AccessBase<Todo, TodoDTO>, ITodoAccess
    {
        public TodoAccess(TodoDbContext context, IMapper mapper) : base (context, mapper)
        {
        }

        public TodoDTO Get(int id, out int errCode)
        {
            errCode = Message.OK;

            try
            {
                return _context.Todos.Where(p => p.Id == id)
                                     .Select(p => _mapper.Map<TodoDTO>(p)).FirstOrDefault();
            }
            catch
            {
                errCode = Message.ExceptionError;
                return default;
            }
        }

        public int GetTodoId()
        {
            return _context.Todos.Max(p => p.Id) + 1;
        }
    }
}
