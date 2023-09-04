using Newtonsoft.Json.Linq;

namespace ToDoAPI.Services
{
    public class TodoService : BaseService<TodoDTO>, ITodoService
    {
        private readonly ITodoAccess _todoAccess;
        private const string TableName = "Todo";

        public TodoService(ITodoAccess todoAccess) : base(todoAccess)
        {
            _todoAccess = todoAccess;
        }

        public IResponse Get(int id, out int errCode)
        {
            try
            {
                // Get from db
                var result = _todoAccess.Get(id, out errCode);
                if (errCode == Message.OK)
                {
                    return new DataResponse(result);
                }
            }
            catch
            {
                errCode = Message.ExceptionError;
            }

            return new MessageResponse(Define.StatusType.ERROR, errCode);
        }

        public IResponse Create(dynamic todoObj, out int errCode, out List<ErrorItem> errList)
        {
            errCode = Message.OK;
            errList = new List<ErrorItem>();

            try
            {
                // Check body format
                if (!CheckType(todoObj, Define.Type.JOBJECT))
                {
                    errCode = Message.InvalidBodyFormat;
                    return null;
                }

                // Check string properties
                var stringProps = new string[] { "Name", "Content" };
                JProperty prop;
                foreach(var stringProp in stringProps)
                {
                    prop = todoObj.Property(stringProp);
                    // Check required field
                    if (prop == null)
                    {
                        CreateErrorList(ref errList, prop, Message.ItemRequired, stringProp);
                    }
                    // Check string type
                    else if (!CheckType(prop.Value, Define.Type.STRING))
                    {
                        CreateErrorList(ref errList, prop, Message.InvalidValue, stringProp, "a string");
                    }
                    // Check min length
                    else if (!CheckStringLength(TableName, prop, Define.LengthType.DEFAULT_MIN, out long length))
                    {
                        CreateErrorList(ref errList, prop, Message.InvalidValue, stringProp, "non-empty");
                    }
                    // Check max length
                    else if (!CheckStringLength(TableName, prop, Define.LengthType.MAX, out long maxLength))
                    {
                        CreateErrorList(ref errList, prop, Message.InvalidValue, stringProp, string.Format("less than {0}", maxLength));
                    }
                }

                var name = "IsComplete";
                prop = todoObj.Property(name);
                // Check boolean type
                if (prop != null && !CheckType(prop.Value, Define.Type.BOOL))
                {
                    CreateErrorList(ref errList, prop, Message.InvalidValue, name, "true or false");
                }

                if (errList.Count > 0)
                {
                    return new ErrorResponse(errList);
                }

                // Insert to db
                todoObj.Id = _todoAccess.GetTodoId();
                _todoAccess.Insert(todoObj, out errCode);
                if (errCode == Message.OK)
                {
                    var result = _todoAccess.Get((int)todoObj.Id, out errCode);
                    if (errCode == Message.OK)
                    {
                        return new DataResponse(result);
                    }
                }
            }
            catch
            {
                errCode = Message.ExceptionError;
            }

            return new MessageResponse(Define.StatusType.ERROR, errCode);
        }

        public IResponse Update(dynamic todoObj, out int errCode, out List<ErrorItem> errList)
        {
            errCode = Message.OK;
            errList = new List<ErrorItem>();

            try
            {
                // Check body format
                if (!CheckType(todoObj, Define.Type.JOBJECT))
                {
                    errCode = Message.InvalidBodyFormat;
                    return null;
                }

                var name = "Id";
                var prop = todoObj.Property(name);
                // Check required field
                if (prop == null)
                {
                    CreateErrorList(ref errList, prop, Message.ItemRequired, name);
                }
                // Check int type
                else if (!CheckType(prop.Value, Define.Type.INT))
                {
                    CreateErrorList(ref errList, prop, Message.InvalidValue, name, "an integer");
                }
                else
                {
                    var todo = _todoAccess.Get((int)prop.Value, out errCode);
                    if (todo == null)
                    {
                        CreateErrorList(ref errList, prop, Message.DataNotExist, name);
                        return new ErrorResponse(errList);
                    }
                }

                // Check string properties
                var stringProps = new string[] { "Name", "Content" };
                foreach (var stringProp in stringProps)
                {
                    prop = todoObj.Property(stringProp);
                    // Do not check if not specified
                    if (prop == null)
                    {
                        continue;
                    }

                    // Check string type
                    if (!CheckType(prop.Value, Define.Type.STRING))
                    {
                        CreateErrorList(ref errList, prop, Message.InvalidValue, stringProp, "a string");
                    }
                    // Check min length
                    else if (!CheckStringLength(TableName, prop, Define.LengthType.DEFAULT_MIN, out long length))
                    {
                        CreateErrorList(ref errList, prop, Message.InvalidValue, stringProp, "non-empty");
                    }
                    // Check max length
                    else if (!CheckStringLength(TableName, prop, Define.LengthType.MAX, out long maxLength))
                    {
                        CreateErrorList(ref errList, prop, Message.InvalidValue, stringProp, string.Format("less than {0}", maxLength));
                    }
                }

                name = "IsComplete";
                prop = todoObj.Property(name);
                // Check boolean type
                if (prop != null && !CheckType(prop.Value, Define.Type.BOOL))
                {
                    CreateErrorList(ref errList, prop, Message.InvalidValue, name, "true or false");
                }

                if (errList.Count > 0)
                {
                    return new ErrorResponse(errList);
                }

                // Update to db
                _todoAccess.Update(todoObj, out errCode);
                if (errCode == Message.OK)
                {
                    var result = _todoAccess.Get((int)todoObj.Id, out errCode);
                    if (errCode == Message.OK)
                    {
                        return new DataResponse(result);
                    }
                }
            }
            catch
            {
                errCode = Message.ExceptionError;
            }

            return new MessageResponse(Define.StatusType.ERROR, errCode);
        }

        public IResponse Delete(int id, out int errCode, out List<ErrorItem> errList)
        {
            errList = new List<ErrorItem>();

            try
            {
                var todo = _todoAccess.Get(id, out errCode);
                // Check required field
                if (todo == null)
                {
                    var name = "Id";
                    CreateErrorList(ref errList, new JProperty(name, id), Message.DataNotExist, name);
                    return new ErrorResponse(errList);
                }

                if (errList.Count == 0)
                {
                    // Delete from db
                    _todoAccess.Delete(id, out errCode);
                    if (errCode == Message.OK)
                    {
                        return new DataResponse(null);
                    }
                }
            }
            catch
            {
                errCode = Message.ExceptionError;
            }

            return new MessageResponse(Define.StatusType.ERROR, errCode);
        }
    }
}
