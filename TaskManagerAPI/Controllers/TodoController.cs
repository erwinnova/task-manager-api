using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.DatabaseContext;
using TaskManagerAPI.DataModel;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.Controllers
{
    
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly MyDatabaseContext _dbcontext;

        public TodoController(MyDatabaseContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet]
        [Route("todos")]
        public async Task<IActionResult> GetTodoList()
        {
            return Ok(_dbcontext.Todos.ToList());
        }

        [HttpPost]
        [Route("todos")]
        public async Task<IActionResult> PostTodo(TodoModel obj)
        {
            TodoDataModel todo = new TodoDataModel();
            todo.Id = Guid.NewGuid();
            todo.todo = obj.todo;
            todo.completed = false;

            _dbcontext.Todos.Add(todo);
            _dbcontext.SaveChanges();

            return Ok(todo);
        }

        [HttpPut]
        [Route("todos")]
        public async Task<IActionResult> UpdateTodo(TodoModel obj)
        {
            TodoDataModel todo = new TodoDataModel();
            todo.Id = Guid.NewGuid();
            todo.todo = obj.todo;
            todo.completed = obj.completed;

            _dbcontext.Todos.Update(todo);
            _dbcontext.SaveChanges();

            return Ok(todo);
        }
    }

}
