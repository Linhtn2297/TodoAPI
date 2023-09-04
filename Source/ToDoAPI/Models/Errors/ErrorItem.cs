namespace ToDoAPI.Models
{
    public class ErrorItem
    {
        /// <summary>Error item name</summary>
        public string Name { get; set; } = null!;
        /// <summary>Error item value</summary>
        public dynamic Value { get; set; } = null!;
        /// <summary>Error code</summary>
        public int ErrorCode { get; set; }
        /// <summary>Error message</summary>
        public string ErrorMessage { get; set; } = null!;
    }
}
