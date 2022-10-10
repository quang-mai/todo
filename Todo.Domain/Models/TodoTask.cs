namespace Todo.Domain.Models
{
     public class TodoTask
    {
        public int Id { get; set; }
        public string? Label { get; set; }
        public bool isCompleted { get; set; }
    }
}