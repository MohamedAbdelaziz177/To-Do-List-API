using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListApi.Models;
using ToDoListApi.Repositories;

namespace ToDoListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoRepository toDoRepository;

        public ToDoController(IToDoRepository toDoRepository)
        {
            this.toDoRepository = toDoRepository;
        }

        [HttpPost]
        public IActionResult AddToDoItem(ToDo todo)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    toDoRepository.Insert(todo);
                    return CreatedAtAction(nameof(GetToDoItem), new { name = todo.Title }, todo);


                }
                catch (Exception ex) { return BadRequest("Error"); }
            }
           
            return BadRequest("Error");
        }

        [HttpGet]
        public IActionResult GetAllToDos()
        {
            return Ok(toDoRepository.GetAll());
        }

        [HttpGet("{name:alpha}")]
        public IActionResult GetToDoItem(string name)
        {
            return Ok(toDoRepository.GetByName(name));
        }

        [HttpPut("{id:int}")]

        public IActionResult MarkToDoItemAsCompleted(int id, [FromBody] ToDo todo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    toDoRepository.Complete(id, todo);
                    return StatusCode(StatusCodes.Status204NoContent);
                }

                return BadRequest("Try Again");
            }

            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteToDoItem(int id) 
        { 
            try
            {
                toDoRepository.Delete(id);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex) { return BadRequest(ex); }
           
        }
    }
}
