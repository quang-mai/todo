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

    /// <summary>
    /// Retrieves all List with the option to include list of todo tasks.
    /// </summary>
    [HttpGet]
    public IEnumerable<TodoList> GetLists(bool withTasks)
    {
      var todoLists = _todoService.GetLists(withTasks);
      return todoLists;
    }

    /// <summary>
    /// Add a Todo List
    /// </summary>
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