using Todo.DataAccess.Models;

namespace Todo.DataAccess.Repository
{
    public interface ITodoListRepository
    {
        IEnumerable<TodoList> GetLists ();
        void AddList(TodoList list);
        TodoList GetList (int listId);
        void Save();
    }

    public class TodoListRepository : BaseRepository, ITodoListRepository 
    {
        public TodoListRepository (TodoContext context) : base(context)
        {
        }

        public IEnumerable<TodoList> GetLists ()
        {
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