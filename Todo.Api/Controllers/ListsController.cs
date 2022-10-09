using System;
using Microsoft.AspNetCore.Mvc;
using Todo.Api.Models;

namespace Todo.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ListsController: ControllerBase
  {
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