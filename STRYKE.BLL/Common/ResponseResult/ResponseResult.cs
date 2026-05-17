namespace STRYKE.BLL.Common.ResponseResult;

public class ResponseResult<T>
{
    public bool IsSuccess { get; private set; }
    public string? Message { get; private set; }
    public int StatusCode { get; private set; }
    public T? Data { get; private set; }

    private ResponseResult() { }

    public static ResponseResult<T> Success(T data, string? message = null)
        => new()
        {
            IsSuccess = true,
            StatusCode = 200,
            Data = data,
            Message = message
        };

    public static ResponseResult<T> Fail(string message, int statusCode = 400)
        => new()
        {
            IsSuccess = false,
            StatusCode = statusCode,
            Message = message
        };

    public static ResponseResult<T> NotFound(string message = "Not found")
        => Fail(message, 404);

    public static ResponseResult<T> Unauthorized(string message = "Unauthorized")
        => Fail(message, 401);

    public static ResponseResult<T> Conflict(string message)
        => Fail(message, 409);
}