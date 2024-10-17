namespace justmami.Application.Commands.AddUser;
public class AddUserValidator : CommandValidator<AddUserCommand>
{
    public AddUserValidator()
    {
        _ = RuleFor(x => x.User.Firstname)
            .NotEmpty().MaximumLength(255);

        _ = RuleFor(x => x.User.Lastname)
            .NotEmpty().MaximumLength(255);

        _ = RuleFor(x => x.User.Password)
            .NotEmpty().MaximumLength(16);

        _ = RuleFor(x => x.User.Email)
            .NotEmpty().EmailAddress().MaximumLength(255);
    }
}
