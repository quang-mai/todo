using Todo.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Todo.DataAccess.Repository
{
    public interface ITodoListRepository
    {
        IEnumerable<TodoList> GetLists (bool withTasks);
        void AddList(TodoList list);
        TodoList GetList (int listId);
        void Save();
    }

    public class TodoListRepository : BaseRepository, ITodoListRepository 
    {
        public TodoListRepository (TodoContext context) : base(context)
        {
        }

        public IEnumerable<TodoList> GetLists (bool withTasks)
        {
            if (withTasks)
            {
                return _context.TodoLists.Include(c => c.Todos).ToList();
            }

            return _context.TodoLists.ToList();
            
        }

        public TodoList GetList (int listId)
        {
            return _context.TodoLists.Find(listId);
        }

        public void AddList(TodoList list)
        {
            _context.TodoLists.Add(list);
        }

        
    }
}