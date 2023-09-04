using Newtonsoft.Json.Linq;

namespace ToDoAPI.Services
{
    public partial class BaseService<DataDTO>
    {
        /// <summary>
        /// Create error list
        /// </summary>
        /// <param name="list">List error</param>
        /// <param name="property">Error property</param>
        /// <param name="errCode">Error code</param>
        /// <param name="errMsg">Error message</param>
        private static void CreateErrorList(ref List<ErrorItem> list, JProperty property, int errCode, string errMsg)
        {
            var error = new ErrorItem();
            error.Name = property.Name;
            error.Value = property.Value;
            error.ErrorCode = errCode;
            error.ErrorMessage = errMsg;

            list = list ?? new List<ErrorItem>();
            list.Add(error);
        }

        /// <summary>
        /// Create error list
        /// </summary>
        /// <param name="list">List error</param>
        /// <param name="property">Error property</param>
        /// <param name="errCode">Error code</param>
        /// <param name="replaceItems">Replace items for message</param>
        protected static void CreateErrorList(ref List<ErrorItem> list, JProperty property, int errCode, params string[] replaceItems)
        {
            property = property ?? new JProperty(replaceItems[0], null);
            CreateErrorList(ref list, property, errCode, String.Format(Message.GetMessage(errCode), replaceItems));
        }

        /// <summary>
        /// Check data type
        /// </summary>
        /// <param name="value">Data to check</param>
        /// <param name="type">Type to check</param>
        /// <returns>true: matching, false: mismatching</returns>
        public static bool CheckType(dynamic value, Define.Type type)
        {
            try
            {
                switch (type)
                {
                    case Define.Type.INT:
                        return int.TryParse((string)value, out int intResult);
                    case Define.Type.STRING:
                        return value is JValue && value != null;
                    case Define.Type.BOOL:
                        return bool.TryParse((string)value, out bool boolResult);
                    case Define.Type.JOBJECT:
                        return value is JObject;
                }
            }
            catch
            {
                return false;
            }

            return false;
        }

        /// <summary>
        /// Check length of string property
        /// </summary>
        /// <param name="tableName">Table name of property</param>
        /// <param name="property">Property to check</param>
        /// <param name="type">Type of length to check</param>
        /// <param name="length">Give length out</param>
        /// <returns>true: valid, false: invalid</returns>
        public static bool CheckStringLength(string tableName, JProperty property, Define.LengthType type, out long length)
        {
            length = 0;

            try
            {
                var propName = property.Name;
                var propValue = (string)property.Value;
                length = Constant.GetLength(tableName, propName, type);

                if (type == Define.LengthType.MIN || type == Define.LengthType.DEFAULT_MIN)
                {
                    return propValue.Length >= length;
                }
                else
                {
                    return propValue.Length <= length;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
