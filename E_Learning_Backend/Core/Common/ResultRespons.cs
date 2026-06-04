namespace E_Learning_Backend.Core.Common
{
    public class ResultRespons
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public static ResultRespons Ok(string message = "Success")
        {
            return new ResultRespons
            {
                Success = true,
                Message = message
            };
        }
        public static ResultRespons Fail(string message)
        {
            return new ResultRespons
            {
                Success = false,
                Message = message
            };
        }
    }
    public class ResultRespons<T> : ResultRespons
    {
        public T? Data { get; set; }

        public static ResultRespons<T> Ok(T data, string message = "Success")
        {
            return new ResultRespons<T>
            {
                Success = true,
                Data = data,
                Message = message
            };
        }
        public static ResultRespons<T> Fail(string message)
        {
            return new ResultRespons<T>
            {
                Success = false,
                Data = default,
                Message = message
            };
        }
    }
}
