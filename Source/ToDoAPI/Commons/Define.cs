namespace ToDoAPI.Commons
{
    public class Define
    {
        /// <summary>
        /// Response status type
        /// </summary>
        public enum StatusType
        {
            OK,
            ERROR
        }

        /// <summary>
        /// Type of data
        /// </summary>
        public enum Type
        {
            INT,
            STRING,
            BOOL,
            JOBJECT
        }

        /// <summary>
        /// Type of string length
        /// </summary>
        public enum LengthType
        {
            MIN,
            MAX,
            DEFAULT_MIN,
            DEFAULT_MAX
        }

        /// <summary>
        /// Response status type dictionary
        /// </summary>
        public static Dictionary<StatusType, string> ResponseStatusTypeDic = new Dictionary<StatusType, string>()
        {
            { StatusType.OK, "success" },
            { StatusType.ERROR, "fail" }
        };
    }
}
