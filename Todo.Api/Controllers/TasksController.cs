using Microsoft.AspNetCore.Mvc;
using Todo.Api.Models;
using Todo.DataAccess.Models;
using Todo.Domain.Service;

namespace Todo.Api.Controllers
{
    [ApiController]
    [Route("api/todo/lists/{listId:int}/[controller]")]
    public class TasksController: ControllerBase
    {
        private readonly ITodoService _todoService;
        public TasksController (ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        [Route("~/api/todo/lists/[controller]")]
        public IEnumerable<Todo.Domain.Models.TodoTask>  GetAllTasks()
        {
            return _todoService.GetAllTasks();
        }

        [HttpGet]
        public IEnumerable<Todo.Domain.Models.TodoTask> GetAllTasks(int listId)
        {
            return _todoService.GetAllTasks(listId);
        }

        [HttpPost]
        public Todo.Domain.Models.TodoTask AddTask(int listId, TodoTaskDTO todoTaskDto)
        {
            var task = new Todo.Domain.Models.TodoTask {
                Label = todoTaskDto.Label
            };

            return _todoService.AddTask(listId, task);
        }

        [HttpPut("{taskId}")]
        public Todo.Domain.Models.TodoTask UpdateTask(int taskId, TodoTaskDTO todoTaskDto)
        {
            var task = new Todo.Domain.Models.TodoTask {
                Id = taskId,
                Label = todoTaskDto.Label,
                isCompleted = todoTaskDto.isCompleted
            };

            return _todoService.UpdateTask(task);
        }

        [HttpDelete("{taskId}")]
        public void DeleteTask(int taskId)
        {
            _todoService.DeleteTask(taskId);
        }
    }
}