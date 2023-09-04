namespace ToDoAPI.Services
{
    public interface IBaseService<DataDTO>
    {
        /// <summary>
        /// Get all data
        /// </summary>
        /// <param name="errCode"></param>
        /// <returns></returns>
        public IResponse GetAll(out int errCode);

        /// <summary>
        /// Start db transaction
        /// </summary>
        public void BeginTransaction();

        /// <summary>
        /// Commit db transaction
        /// </summary>
        public void Commit();

        /// <summary>
        /// Rollback db transaction
        /// </summary>
        public void Rollback();
    }
}
