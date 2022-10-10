using Todo.Domain.Models;
using Todo.DataAccess.Repository;

namespace Todo.Domain.Service
{
    public interface ITodoService
    {
        IEnumerable<TodoList> GetLists ();
        TodoList AddList(TodoList todoList);
        IEnumerable<TodoTask> GetAllTasks (int listId);
        IEnumerable<TodoTask> GetAllTasks ();
        TodoTask AddTask(int listId, TodoTask todoTask);
        TodoTask UpdateTask (TodoTask todoTask);
        void DeleteTask (int taskId);
    }

    public class TodoService : ITodoService
    {
        private readonly ITodoListRepository _todoListRepository;
        private readonly ITodoTaskRepository _todoTaskRepository;

        public TodoService (ITodoListRepository todoListRepository, ITodoTaskRepository todoTaskRepository)
        {
            _todoListRepository = todoListRepository;
            _todoTaskRepository = todoTaskRepository;
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

        public IEnumerable<TodoTask> GetAllTasks (int listId)
        {
            var result =  _todoTaskRepository.GetTasks(listId);

            List<TodoTask> todoTasks = new List<TodoTask>();

            foreach (var task in result) 
            {
                todoTasks.Add(new TodoTask 
                {
                    Id = task.Id,
                    Label = task.Label,
                    isCompleted = task.isCompleted
                });
            }

            return todoTasks;
        }

        public IEnumerable<TodoTask> GetAllTasks ()
        {
            var result =  _todoTaskRepository.GetTasks();

            List<TodoTask> todoTasks = new List<TodoTask>();

            foreach (var task in result) 
            {
                todoTasks.Add(new TodoTask 
                {
                    Id = task.Id,
                    Label = task.Label,
                    isCompleted = task.isCompleted
                });
            }

            return todoTasks;
        }

        public TodoTask AddTask(int listId, TodoTask todoTask)
        {
            //check if list exists

            var task = new DataAccess.Models.TodoTask {
                Label = todoTask.Label,
                TodoListId = listId
            };

            _todoTaskRepository.AddTask(task);
            _todoTaskRepository.Save();

            return new TodoTask {
                Id = task.Id,
                Label = task.Label,
                isCompleted = task.isCompleted
            };

        }

        public TodoTask UpdateTask (TodoTask todoTask)
        {
            var task = _todoTaskRepository.GetTask(todoTask.Id);
            task.Label = todoTask.Label;
            task.isCompleted = todoTask.isCompleted;

            _todoTaskRepository.UpdateTask(task);
            _todoTaskRepository.Save();

            return new TodoTask {
                Id = task.Id,
                Label = task.Label,
                isCompleted = task.isCompleted
            };
        }

        public void DeleteTask (int taskId)
        {
           var task =  _todoTaskRepository.GetTask(taskId);
           _todoTaskRepository.DeleteTask(task);
           _todoTaskRepository.Save();
        }
    }
}