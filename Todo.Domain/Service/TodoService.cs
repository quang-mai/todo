using Todo.Domain.Models;
using Todo.DataAccess.Repository;

namespace Todo.Domain.Service
{
    public interface ITodoService
    {
        IEnumerable<TodoList> GetLists ();
        TodoList AddList(TodoList todoList);
    }

    public class TodoService : ITodoService
    {
        private readonly ITodoListRepository _todoListRepository;

        public TodoService (ITodoListRepository todoListRepository)
        {
            _todoListRepository = todoListRepository;
        }

        public IEnumerable<TodoList> GetLists ()
        {
            var list = _todoListRepository.GetLists();

            List<TodoList> todoList = new List<TodoList>();

            foreach (var item in list) 
            {
                todoList.Add(new TodoList 
                {
                    Id = item.Id,
                    Label = item.Label
                });
            }

            return todoList;
        }

        public TodoList AddList(TodoList todoList)
        {
            var dalList = new Todo.DataAccess.Models.TodoList {
                Label = todoList.Label
            };

            _todoListRepository.AddList(dalList);
            _todoListRepository.Save();

            var newList = new TodoList {
                Id = dalList.Id,
                Label = dalList.Label
            };

            return newList;
        }

    }
}