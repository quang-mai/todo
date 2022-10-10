namespace Todo.Api.Models
{
    public class TodoTaskDTO
    {
        public int Id {get;set;}
        public string? Label { get; set; }
        public bool isCompleted { get; set; }
    }
}