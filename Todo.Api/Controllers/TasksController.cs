using Microsoft.AspNetCore.Mvc;
using Todo.Api.Models;

namespace Todo.Api.Controllers
{
    [ApiController]
    [Route("api/todo/lists/{listId:int}/[controller]")]
    public class TasksController: ControllerBase
    {
        [HttpGet]
        [Route("~/api/todo/lists/[controller]")]
        public int GetAllTasks()
        {
            return 2000;
        }

        [HttpGet]
        public int GetAllTasks(int listId)
        {
            return listId;
        }

        [HttpPost]
        public int AddTask(TodoTaskDTO todoTaskDto)
        {
            return 200;
        }

        [HttpPut("{taskId}")]
        public long UpdateTask(long taskId, TodoTaskDTO todoTaskDto)
        {
            return taskId;
        }

        [HttpDelete("{taskId}")]
        public long DeleteTask(long taskId)
        {
            return taskId;
        }
    }
}