namespace ToDoAPI.DB
{
    public interface IAccessBase<DataDTO>
    {
        /// <summary>
        /// Get all data from db
        /// </summary>
        /// <param name="errCode">Error code</param>
        /// <returns>List data DTO</returns>
        public List<DataDTO> GetAll(out int errCode);

        /// <summary>
        /// Insert data into db
        /// </summary>
        /// <param name="obj">Data to insert</param>
        /// <param name="errCode">Error code</param>
        public void Insert(dynamic objDTO, out int errCode);

        /// <summary>
        /// Update data into db
        /// </summary>
        /// <param name="obj">Data to update</param>
        /// <param name="errCode">Error code</param>
        public void Update(dynamic objDTO, out int errCode);

        /// <summary>
        /// Delete data from db
        /// </summary>
        /// <param name="id">Todo id</param>
        /// <param name="errCode">Error code</param>
        public void Delete(int id, out int errCode);

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
