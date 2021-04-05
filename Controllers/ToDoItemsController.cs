using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoItems.Data;
using ToDoItems.Models;

namespace ToDoItems.Controllers
{
    [ApiController]
    //api/todoitems
    [Route("api/todoitems")]
    
    public class ToDoItemsController : ControllerBase
    {
        private readonly IToDoRepository repository;

        public ToDoItemsController(IToDoRepository _repository)
        {
            repository = _repository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ToDoItem>>GetallToDoItems()
        {
             var items = repository.GetAllToDoItems();
            return Ok(items);
        }
        [HttpGet("{id}")]
        public ActionResult<ToDoItem> GetToDoItemByID(int id)
        {
            var item = repository.GetToDoItemByID(id);
            if (item!=null)
            {
                return Ok(item);
            }
            else
            {
                return NotFound();
            }
        }

       [HttpPost]
       public ActionResult<ToDoItem> CreateToDoItem(ToDoItem item)
        {
            repository.CreateToDoItem(item);
            repository.SaveChanges();
            return Ok(item);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateToDoItem(int id,ToDoItem newItem)
        {
            var oldItem = repository.GetToDoItemByID(id);
            if (oldItem==null)
            {
                return NotFound();
            }
            oldItem.Title = newItem.Title;
            oldItem.Status = newItem.Status;
            repository.UpdateToDoItem(oldItem);
            repository.SaveChanges();
            return NoContent();
        }
    }
}
