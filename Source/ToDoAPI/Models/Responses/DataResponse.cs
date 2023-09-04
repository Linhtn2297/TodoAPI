namespace ToDoAPI.Models
{
    public class DataResponse : IResponse
    {
        /// <summary>Response status</summary>
        public string Status { get; set; }

        /// <summary>Response data</summary>
        public object Data { get; set; }

        public DataResponse(object data)
        {
            Status = Define.ResponseStatusTypeDic[Define.StatusType.OK];
            Data = data;
        }
    }
}
