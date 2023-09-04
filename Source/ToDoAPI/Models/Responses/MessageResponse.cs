namespace ToDoAPI.Models
{
    public class MessageResponse : IResponse
    {
        /// <summary>Response status</summary>
        public string Status { get; set; }

        /// <summary>Response message</summary>
        public string Message { get; set; }

        public MessageResponse(Define.StatusType statusType, int errCode)
        {
            Status = Define.ResponseStatusTypeDic[statusType];
            Message = Commons.Message.GetMessage(errCode);
        }
    }
}
