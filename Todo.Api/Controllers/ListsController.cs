using Microsoft.AspNetCore.Mvc;
using Todo.Api.Models;
using Todo.Domain.Models;
using Todo.Domain.Service;

namespace Todo.Api.Controllers
{ 
  [ApiController]
  [Route("api/todo/[controller]")]
  public class ListsController: ControllerBase
  {
    private readonly ITodoService _todoService;

    public ListsController (ITodoService todoService)
    {
      _todoService = todoService;
    }

    [HttpGet]
    public IEnumerable<TodoList> GetLists()
    {
      var todoLists = _todoService.GetLists();
      return todoLists;
    }

    [HttpPost]
    public TodoList AddList(TodoListDTO listDTO)
    {
      var list = new TodoList {
        Label = listDTO.Label
      };

      return _todoService.AddList(list);
    }
  }
}