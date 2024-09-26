using FluentValidation;
using MediatR;

namespace justmami.Application.Core;
public interface ICommand<TResponse> : IRequest<TResponse> { }

// Marker interface for queries
public interface IQuery<TResponse> : IRequest<TResponse> { }

public abstract class CommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, TResponse> where TCommand : ICommand<TResponse>
{
    public abstract Task<TResponse> Handle(TCommand command, CancellationToken cancellationToken);
}

// Base class for query handlers
public abstract class QueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse> where TQuery : IQuery<TResponse>
{
    public abstract Task<TResponse> Handle(TQuery query, CancellationToken cancellationToken);
}

public class Result
{
    public bool IsSuccess { get; }
    public string Error { get; }

    protected Result(bool isSuccess, string error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success() => new(true, null!);
    public static Result Failure(string error) => new(false, error);
}

public class Result<T> : Result
{
    public T Value { get; }

    protected Result(bool isSuccess, string error, T value) : base(isSuccess, error) => Value = value;

    public static Result<T> Success(T value) => new(true, null!, value);
    public static new Result<T> Failure(string error) => new(false, error, default!);
}

public abstract class CommandValidator<TCommand> : AbstractValidator<TCommand> { }

public abstract class QueryValidator<TQuery> : AbstractValidator<TQuery> { }