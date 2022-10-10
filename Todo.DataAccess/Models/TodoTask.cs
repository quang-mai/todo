using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Todo.DataAccess.Models
{
    public class TodoTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Label { get; set; }
        public bool isCompleted { get; set; }

        public TodoList TodoList {get; set;}
        public int TodoListId {get;set;}
    }
}