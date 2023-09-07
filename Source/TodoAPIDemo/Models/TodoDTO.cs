namespace TodoAPIDemo.Models
{
    public class TodoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public bool IsComplete { get; set; }

        public TodoDTO(int id, string name, string content, bool isComplete)
        {
            Id = id;
            Name = name;
            Content = content;
            IsComplete = isComplete;
        }
    }
}
