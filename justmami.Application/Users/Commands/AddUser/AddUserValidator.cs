using FluentValidation;
using justmami.Application.Core;

namespace justmami.Application.Users.Commands.AddUser;
public class AddUserValidator : CommandValidator<AddUserCommand>
{
    public AddUserValidator() => RuleFor(x => x.User.Id).NotEmpty();
}
