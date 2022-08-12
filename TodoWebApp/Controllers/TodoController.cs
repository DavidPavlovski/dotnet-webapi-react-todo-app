
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoWebApp.Domain;
using TodoWebApp.Services.Abstraction;

namespace TodoWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            List<Todo> todos = _todoService.GetAll();
            return Ok(todos);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            Todo todo = _todoService.GetById(id);
            return Ok(todo);
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] Todo todo)
        {
           int id =  _todoService.Create(todo);
            return Ok(id);
        }

        [HttpPut("Edit/id/{id}")]
        public IActionResult Edit([FromRoute] int id, [FromBody] Todo todo)
        {
            _todoService.Edit(id, todo);
            return Ok();
        }
        [HttpDelete("Delete/id/{id}")]

        public IActionResult Delete([FromRoute] int id)
        {
            _todoService.Delete(id);
            return Ok();
        }
    }
}
