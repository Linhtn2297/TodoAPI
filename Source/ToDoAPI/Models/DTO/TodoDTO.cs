namespace ToDoAPI.Models
{
    public class TodoDTO
    {
        /// <summary>Todo id</summary>
        public int Id { get; set; }
        /// <summary>Todo name</summary>
        public string Name { get; set; } = null!;
        /// <summary>Todo content</summary>
        public string Content { get; set; } = null!;
        /// <summary>Todo has been completed or not</summary>
        public bool IsComplete { get; set; }
    }
}
