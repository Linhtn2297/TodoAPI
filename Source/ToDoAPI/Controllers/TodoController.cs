using Microsoft.AspNetCore.Mvc;

namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
            _todoService.BeginTransaction();
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                var response = _todoService.GetAll(out int errCode);
                if (errCode == Message.OK)
                {
                    _todoService.Commit();
                    return Ok(response);
                }
                else
                {
                    _todoService.Rollback();
                    if (errCode == Message.ExceptionError)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, response);
                    }

                    return BadRequest(response);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new MessageResponse(Define.StatusType.ERROR, Message.ExceptionError));
            }
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                var response = _todoService.Get(id, out int errCode);
                if (errCode == Message.OK)
                {
                    _todoService.Commit();
                    return Ok(response);
                }
                else
                {
                    _todoService.Rollback();
                    if (errCode == Message.ExceptionError)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, response);
                    }

                    return BadRequest(response);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new MessageResponse(Define.StatusType.ERROR, Message.ExceptionError));
            }
        }

        [HttpPost]
        public ActionResult Post(dynamic todoObj)
        {
            try
            {
                var response = _todoService.Create(todoObj, out int errCode, out List<ErrorItem> errList);
                if (errCode == Message.OK && errList.Count == 0)
                {
                    _todoService.Commit();
                    return Ok(response);
                }
                else
                {
                    _todoService.Rollback();
                    if (errCode == Message.ExceptionError)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, response);
                    }

                    return BadRequest(response);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new MessageResponse(Define.StatusType.ERROR, Message.ExceptionError));
            }
        }

        [HttpPut]
        public ActionResult Put(dynamic todoObj)
        {
            try
            {
                var response = _todoService.Update(todoObj, out int errCode, out List<ErrorItem> errList);
                if (errCode == Message.OK && errList.Count == 0)
                {
                    _todoService.Commit();
                    return Ok(response);
                }
                else
                {
                    _todoService.Rollback();
                    if (errCode == Message.ExceptionError)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, response);
                    }

                    return BadRequest(response);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new MessageResponse(Define.StatusType.ERROR, Message.ExceptionError));
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var response = _todoService.Delete(id, out int errCode, out List<ErrorItem> errList);
                if (errCode == Message.OK && errList.Count == 0)
                {
                    _todoService.Commit();
                    return Ok(response);
                }
                else
                {
                    _todoService.Rollback();
                    if (errCode == Message.ExceptionError)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, response);
                    }

                    return BadRequest(response);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new MessageResponse(Define.StatusType.ERROR, Message.ExceptionError));
            }
        }
    }
}

