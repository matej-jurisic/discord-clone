namespace Shared.Results
{
    public class Result : ResultBase
    {
        public static Result Success() => new() { StatusCode = ResultStatusCodes.Ok };
        public static Result<T> Success<T>(T data) => new() { Data = data, StatusCode = ResultStatusCodes.Ok };

        public static Result Failure(ResultStatusCodes statusCode, string message) => new()
        {
            StatusCode = statusCode,
            Messages = [message]
        };

        public static Result<T> Failure<T>(ResultStatusCodes statusCode, string message) => new()
        {
            StatusCode = statusCode,
            Messages = [message]
        };

        public static implicit operator Result(ResultStatusCodes statusCode) => Failure(statusCode, statusCode.ToString());
    }

    public class Result<T> : ResultBase
    {
        public T Data { get; init; } = default!;

        public static implicit operator Result<T>(Result result) => new()
        {
            Data = default!,
            StatusCode = result.StatusCode,
            Messages = result.Messages
        };
    }
}
