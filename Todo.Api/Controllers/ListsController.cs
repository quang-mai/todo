using System;
using Microsoft.AspNetCore.Mvc;
using Todo.Api.Models;
using Todo.Domain.Service;

namespace Todo.Api.Controllers
{ 
  [ApiController]
  [Route("api/[controller]")]
  public class ListsController: ControllerBase
  {
    private readonly ITodoService _todoService;

    public ListsController (ITodoService todoService)
    {
      _todoService = todoService;
    }

    [HttpGet]
    public bool GetLists()
    {
      return true;
    }

    [HttpPost]
    public ListDTO AddLists(ListDTO listDTO)
    {
      return new ListDTO {
        Label = listDTO.Label
      };
    }
  }
}