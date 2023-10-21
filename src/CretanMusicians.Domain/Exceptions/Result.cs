namespace CretanMusicians.Domain.Exceptions;

public class Result<TValue>
{
    public Exception? Exception { get; }
    public bool IsSuccess { get; }
    public TValue? Value { get; }

    private Result(TValue? value)
    {
        IsSuccess = true;
        Value = value;
    }

    public Result(Exception exception)
    {
        IsSuccess = false;
        Exception = exception;
    }

    public TAction Match<TAction>(Func<TValue?, TAction> success, Func<Exception, TAction> failure)
        => IsSuccess ? success(Value) : failure(Exception!);

    public static implicit operator Result<TValue>(TValue value) => new(value);
}