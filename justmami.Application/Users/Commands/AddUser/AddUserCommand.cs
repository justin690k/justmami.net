namespace justmami.Application.Users.Commands.AddUser;
public class AddUserCommand : ICommand<Result<bool>>
{
    public required User User { get; set; }
}