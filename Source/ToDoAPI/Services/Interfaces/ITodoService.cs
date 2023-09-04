namespace ToDoAPI.Services
{
    public interface ITodoService : IBaseService<TodoDTO>
    {
        /// <summary>
        /// Get todo by id
        /// </summary>
        /// <param name="id">Todo id</param>
        /// <param name="errCode">error code</param>
        /// <returns>Todo</returns>
        public IResponse Get(int id, out int errCode);

        /// <summary>
        /// Update Todo
        /// </summary>
        /// <param name="todoObj">Todo data for update</param>
        /// <param name="errCode">Error code</param>
        /// <param name="errList">Error list</param>
        /// <returns>Response</returns>
        public IResponse Update(dynamic todoObj, out int errCode, out List<ErrorItem> errList);

        /// <summary>
        /// Create new Todo
        /// </summary>
        /// <param name="todoObj">Todo data for insert</param>
        /// <param name="errCode">Error code</param>
        /// <param name="errList">Error list</param>
        /// <returns>Response</returns>
        public IResponse Create(dynamic todoObj, out int errCode, out List<ErrorItem> errList);

        /// <summary>
        /// Delete Todo by id
        /// </summary>
        /// <param name="id">Todo id</param>
        /// <param name="errCode">Error code</param>
        /// <param name="errList">Error list</param>
        /// <returns>Response</returns>
        public IResponse Delete(int id, out int errCode, out List<ErrorItem> errList);
    }
}
