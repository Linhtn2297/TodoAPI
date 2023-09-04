namespace ToDoAPI.Commons
{
    public class Constant
    {
        /// <summary>Default min length of a string</summary>
        public const int STRING_MIN_LENGTH = 1;
        /// <summary>Max length of todo name</summary>
        public const int TODO_NAME_MAX_LENGTH = 100;
        /// <summary>Max length of todo content</summary>
        public const long TODO_CONTENT_MAX_LENGTH = 4294967295; // Max length of longtext

        /// <summary>
        /// Get constant by name
        /// </summary>
        /// <param name="name">Name</param>
        /// <returns>Constant</returns>
        private static long GetConstant(string name)
        {
            var infoList = typeof(Constant).GetFields();
            foreach (var info in infoList)
            {
                if (name.ToUpper() == info.Name)
                {
                    return Convert.ToInt64(info.GetValue(null));
                }
            }

            return 0;
        }

        /// <summary>
        /// Get length constant by table name, field name and type
        /// </summary>
        /// <param name="table">Table name</param>
        /// <param name="fieldName">Field name</param>
        /// <param name="type">Type length to get</param>
        /// <returns>Length constant</returns>
        public static long GetLength(string table, string fieldName, Define.LengthType type)
        {
            var name = string.Empty;
            switch (type)
            {
                case Define.LengthType.MIN: name = string.Format("{0}_{1}_{2}", table, fieldName, "MIN"); break;
                case Define.LengthType.MAX: name = string.Format("{0}_{1}_{2}", table, fieldName, "MAX"); break;
                case Define.LengthType.DEFAULT_MIN: name = "STRING_MIN"; break;
                case Define.LengthType.DEFAULT_MAX: name = "STRING_MAX"; break;
            }

            return GetConstant(string.Format("{0}_LENGTH", name));
        }
    }
}
