namespace ToDoAPI.DB
{
    public interface ITodoAccess : IAccessBase<TodoDTO>
    {
        /// <summary>
        /// Get todo by id
        /// </summary>
        /// <param name="id">Todo id</param>
        /// <param name="errCode">Error code</param>
        /// <returns>TodoDTO</returns>
        public int GetTodoId();

        /// <summary>
        /// Get next todo id for insert
        /// </summary>
        /// <returns>Next todo id</returns>
        public TodoDTO Get(int id, out int errCode);
    }
}
