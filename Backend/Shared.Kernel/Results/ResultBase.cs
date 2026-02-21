namespace Shared.Kernel.Results;

public abstract class ResultBase
{
    public IReadOnlyCollection<string> Messages { get; init; } = [];
    public ResultStatusCodes StatusCode { get; init; }
    public bool IsSuccess => StatusCode is ResultStatusCodes.Ok or ResultStatusCodes.Created;
    public bool IsFailure => !IsSuccess;

}
