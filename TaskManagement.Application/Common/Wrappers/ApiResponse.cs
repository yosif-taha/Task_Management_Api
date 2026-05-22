
namespace TaskManagement.Application.Common.Wrappers
{
    public class ApiResponse<T>
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<string> Errors { get; set; } = new();
        public T? Data { get; set; }

        public ApiResponse(T data, string message = "")
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }

        public ApiResponse(bool succeeded, string message = "")
        {
            Succeeded = succeeded;
            Message = message;
        }

        public ApiResponse(string message, List<string>? errors = null)
        {
            Succeeded = false;
            Message = message;
            if (errors != null)
            {
                Errors = errors;
            }
        }

        public static ApiResponse<T> Success(T data, string message = "") => new(data, message);
        public static ApiResponse<T> Success(string message = "") => new(true, message);
        public static ApiResponse<T> Fail(string message, List<string>? errors = null) => new(message, errors);
    }
}
