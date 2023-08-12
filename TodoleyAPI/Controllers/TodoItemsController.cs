using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using TodoleyAPI.DTO;
using TodoleyAPI.Models;
using TodoleyAPI.Services.TodoItemsService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoleyAPI.Controllers
{
    [Authorize]
    [Route("api/todo-items")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly ITodoItemsService _todoItemsService;
        public TodoItemsController(ITodoItemsService service)
        {
            _todoItemsService = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<TodoItem>>> Get()
        {
            var result =  _todoItemsService.GetAll().ToList();
            return Ok(result);
        }

        // GET api/<TodoItemsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> Get(int id)
        {
            var result = _todoItemsService.GetById(id);
            if (result == null)
            {
                return NotFound("Record not found");
            }
            return Ok(result);
        }

        // POST api/<TodoItemsController>
        [HttpPost]
        public async Task<ActionResult<TodoItem>> Post([FromBody] TodoItem item)
        {
           if (item == null)
            {
                return BadRequest("Body is null");
            }
           _todoItemsService.Add(item);
            return Ok(Get());
        }

        // PUT api/<TodoItemsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<TodoItem>> Put([FromBody] TodoItem item)
        {
            if(item == null)
            {
                return BadRequest("Body is null");
            }
            _todoItemsService.Update(item);
            return Ok(Get());
        }

        // DELETE api/<TodoItemsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoItem>> Delete(int id)
        {
            _todoItemsService.Delete(id);
            return Ok(Get());
        }
    }
}
