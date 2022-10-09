using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/lists/{listId:int}/[controller]")]
    public class TodosController: ControllerBase
    {
        [HttpGet]
        [Route("~/api/lists/[controller]")]
        public int GetAllTodos()
        {
            return 2000;
        }

        [HttpGet]
        public int GetAllTodos(int listId)
        {
            return listId;
        }

        [HttpPost]
        public int AddTodos(TodoDTO todoDto)
        {
            return 200;
        }

        [HttpPut("{todoId}")]
        public long UpdateTodo(long todoId, TodoDTO todoDto)
        {
            return todoId;
        }

        [HttpDelete("{todoId}")]
        public long DeleteTodo(long todoId)
        {
            return todoId;
        }
    }
}