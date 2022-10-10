using Todo.DataAccess.Models;

namespace Todo.DataAccess.Repository
{
    public interface ITodoTaskRepository
    {
        IEnumerable<TodoTask> GetTasks ();
        TodoTask GetTask (int taskId);
        IEnumerable<TodoTask> GetTasks (int listId);
        void AddTask (TodoTask todoTask);
        void UpdateTask (TodoTask todoTask);
        void DeleteTask (TodoTask todoTask);
        void Save();
    }

  public class TodoTaskRepository : BaseRepository, ITodoTaskRepository
  {
    public TodoTaskRepository(TodoContext context) : base(context){}

    public IEnumerable<TodoTask> GetTasks ()
    {
        return _context.TodoTasks;
    }

     public TodoTask GetTask (int taskId)
    {
        return _context.TodoTasks.Single(task => task.Id == taskId);
    }

    public IEnumerable<TodoTask> GetTasks (int listId)
    {
        return _context.TodoTasks.Where( task => task.TodoListId == listId);
    }

    public void AddTask (TodoTask todoTask)
    {
        _context.TodoTasks.Add(todoTask);
    }

    public void UpdateTask (TodoTask todoTask)
    {
        _context.TodoTasks.Update(todoTask);
    }

    public void DeleteTask (TodoTask todoTask)
    {
        _context.TodoTasks.Remove(todoTask);
    }
  }
}