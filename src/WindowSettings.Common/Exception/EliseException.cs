namespace WindowSettings.Common.Exception
{
    public class EliseException : System.Exception
    {
        public EliseException(int errorCode, string message, string field = null) : base(message)
        {
            ErrorCode = errorCode;
            Field = field;
        }

        public int ErrorCode { get; set; }
        public string Field { get; set; }
    }
}
