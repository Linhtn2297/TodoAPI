namespace ToDoAPI.Commons
{
    public class Message
    {
        #region Success message
        public const int OK = 0;
        public const string OKMsg = "Success!";
        #endregion

        #region Error message
        public const int ExceptionError = 9999;
        public const string ExceptionErrorMsg = "Something went wrong!";
        public const int InvalidBodyFormat = 9997;
        public const string InvalidBodyFormatMsg = "Body format is invalid!";
        public const int ItemRequired = 9996;
        public const string ItemRequiredMsg = "'{0}' is required!";
        public const int InvalidValue = 9995;
        public const string InvalidValueMsg = "'{0}' is invalid, value must be {1}!";
        public const int DataNotExist = 9994;
        public const string DataNotExistMsg = "{0} does not exist!";
        #endregion

        /// <summary>
        /// Get message by code
        /// </summary>
        /// <param name="code">Message code</param>
        /// <returns>Message</returns>
        public static string GetMessage(int code)
        {
            var infoList = typeof(Message).GetFields().Where(p => p.FieldType.Name == "Int32");

            foreach (var info in infoList)
            {
                if (code == (int)info.GetValue(null))
                {
                    var field = typeof(Message).GetField(info.Name + "Msg");
                    if (field != null)
                    {
                        return (string)field.GetValue(null);
                    }
                }
            }

            return string.Empty;
        }
    }
}
