using Todo.DataAccess.Models;

namespace Todo.DataAccess.Repository
{
    public interface ITodoListRepository
    {
        IEnumerable<TodoList> GetLists ();
        void AddList(TodoList list);
        void Save();
    }

    public class TodoListRepository : ITodoListRepository
    {
        private readonly TodoContext _context;

        public TodoListRepository (TodoContext context)
        {
            _context = context;
        }

        public IEnumerable<TodoList> GetLists ()
        {
            return _context.TodoLists.ToList();
        }

        public void AddList(TodoList list)
        {
            _context.TodoLists.Add(list);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}