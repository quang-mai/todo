using System;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Controllers
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