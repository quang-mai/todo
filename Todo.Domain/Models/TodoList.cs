namespace Todo.Domain.Models
{
   public class TodoList
    {
        public int Id { get; set; }
        public string? Label { get; set; }
        public IEnumerable<TodoTask>? Todos { get; set; }
    }
}