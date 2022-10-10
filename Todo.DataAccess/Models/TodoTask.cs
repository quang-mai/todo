namespace Todo.DataAccess.Models
{
    public class TodoTask
    {
        public int Id { get; set; }
        public string? Label { get; set; }
        public bool isCompleted { get; set; }

        public TodoList TodoList {get; set;}
        public int TodoListId {get;set;}
    }
}