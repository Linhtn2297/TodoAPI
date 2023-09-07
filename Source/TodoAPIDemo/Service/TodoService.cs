using TodoAPIDemo.DB.Access;
using TodoAPIDemo.DB.Entitys;

namespace TodoAPIDemo.Service
{
    public class TodoService
    {
        private readonly TodoAccess _todoAccess;

        public TodoService(TodoAccess todoAccess)
        {
            _todoAccess = todoAccess;
        }

        public List<Todo> GetAll()
        {
            return _todoAccess.Get();
        }

        public void Insert(Todo todo)
        {
            // validate here ...
            // check input, logic here ...

            todo.Id = _todoAccess.GetNextId();
            _todoAccess.Insert(todo);
        }

        public void Update(Todo todo)
        {
            // validate here ...
            // check input, logic here ...

            _todoAccess.Update(todo);
        }

        public void Delete(int id)
        {
            // validate here ...
            // check input, logic here ...

            _todoAccess.Delete(id);
        }
    }
}
