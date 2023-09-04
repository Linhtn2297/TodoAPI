using Microsoft.AspNetCore.Mvc;

namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        [HttpGet]
        public IActionResult HandleError()
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new MessageResponse(Define.StatusType.ERROR, Message.ExceptionError));
        }
    }
}
