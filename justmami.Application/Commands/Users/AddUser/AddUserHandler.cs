namespace justmami.Application.Commands.AddUser;
public class AddUserHandler : CommandHandler<AddUserCommand, Result<bool>>
{
    public override async Task<Result<bool>> Handle(AddUserCommand command, CancellationToken cancellationToken)
    {
        //New Validation logic just copy
        FluentValidation.Results.ValidationResult validationResult = new AddUserValidator().Validate(command);
        if (validationResult is { IsValid: false, Errors.Count: > 0 })
            return Result<bool>.Failure(string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage)));
        else if (validationResult is { IsValid: false })
            return Result<bool>.Failure("Validation failed with unknown errors.");


        //Access Repository
        await Task.Delay(100, cancellationToken);

        return Result<bool>.Success(true);
    }
}
