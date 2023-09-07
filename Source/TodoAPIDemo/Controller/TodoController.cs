using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoAPIDemo.DB.Entitys;
using TodoAPIDemo.Service;

namespace TodoAPIDemo.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoService _todoService;
        public TodoController(TodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_todoService.GetAll());
        }

        [HttpPost]
        public ActionResult Post(Todo todo)
        {
            _todoService.Insert(todo);
            return Ok("Insert successfully!");
        }

        [HttpPut]
        public ActionResult Put(Todo todo)
        {
            _todoService.Update(todo);
            return Ok("Update successfully!");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _todoService.Delete(id);
            return Ok("Delete successfully!");
        }
    }
}
