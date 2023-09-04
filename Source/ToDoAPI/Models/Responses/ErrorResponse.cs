namespace ToDoAPI.Models
{
    public class ErrorResponse : IResponse
    {
        /// <summary>Response status</summary>
        public string Status { get; set; }

        /// <summary>Response errors</summary>
        public object Errors { get; set; }

        public ErrorResponse(object data)
        {
            Status = Define.ResponseStatusTypeDic[Define.StatusType.ERROR];
            Errors = data;
        }
    }
}
