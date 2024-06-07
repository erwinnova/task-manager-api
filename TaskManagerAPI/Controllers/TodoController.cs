using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet]
        [Route("todos/{id}")]
        public async Task<IActionResult> GetTodoDetails(Guid id)
        {
            return Ok(_dbcontext.Todos.Find(id));
        }

        [HttpPost]
        [Route("todos")]
        public async  Task<IActionResult> PostTodo(TodoModel obj)
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
        [Route("todos/{id}")]
        public async Task<IActionResult> UpdateTodo(TodoModel obj, Guid id)
        {
            TodoDataModel todo = new TodoDataModel();
            todo.todo = obj.todo;
            todo.completed = obj.completed;
            todo.Id = id;

            _dbcontext.Todos.Update(todo);
            _dbcontext.SaveChanges();

            return Ok(todo);
        }

        [HttpDelete]
        [Route("todos/{id}")]
        public async Task<IActionResult> DeleteTodo(Guid id)
        {
            var todo = new TodoDataModel { Id = id };

            _dbcontext.Todos.Attach(todo);
            _dbcontext.Todos.Remove(todo);
            _dbcontext.SaveChanges();

            return Ok();
        }
    }

}
