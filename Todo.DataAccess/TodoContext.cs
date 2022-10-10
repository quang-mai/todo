using Microsoft.EntityFrameworkCore;
using Todo.DataAccess.Models;

namespace Todo.DataAccess
{
    public class TodoContext : DbContext
    {
        public DbSet<TodoList> TodoLists {get;set;}
        public DbSet<Todo.DataAccess.Models.TodoTask> TodoTasks {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("User Id = admin;password=password;Server=localhost;Port=5432;Database=Todo;Integrated Security=true; Pooling=true");
       
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            SeedTodoList(modelBuilder);
            SeedTodos(modelBuilder);
        }

        private void SeedTodoList (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoList>()
                .HasData(
                    new TodoList
                    {
                        Id = 1, 
                        Label = "Homework",
                    },
                    new TodoList
                    {
                        Id = 2, 
                        Label = "House",
                    }
                );
        }

        private void SeedTodos(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo.DataAccess.Models.TodoTask>()
                .HasData(
                    new Todo.DataAccess.Models.TodoTask {Id = 1,TodoListId = 1,Label = "Math"},
                    new Todo.DataAccess.Models.TodoTask {Id = 2,TodoListId = 1,Label = "History"},
                    new Todo.DataAccess.Models.TodoTask {Id = 3,TodoListId = 1,Label = "Science"},


                    new Todo.DataAccess.Models.TodoTask {Id = 4,TodoListId = 2,Label = "Mow Lawn"},
                    new Todo.DataAccess.Models.TodoTask {Id = 5,TodoListId = 2,Label = "Clean bathroom"}
                );
        }
    }
}