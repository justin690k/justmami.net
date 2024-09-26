﻿using justmami.Application.Core;

namespace justmami.Application.Users.Commands.AddUser;
internal class AddUserHandler : CommandHandler<AddUserCommand, Result<bool>>
{
    public override async Task<Result<Boolean>> Handle(AddUserCommand command, CancellationToken cancellationToken)
    {
        var validator = new AddUserValidator();

        if (validator.Validate(command) is { IsValid: false } x)
            return Result<bool>.Failure(x.Errors.ToString());

        //WORK
        await Task.Delay(100);

        return Result<bool>.Success(true);
    }
}
