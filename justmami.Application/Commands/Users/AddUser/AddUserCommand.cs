namespace justmami.Application.Commands.AddUser;
public class AddUserCommand : ICommand<Result<bool>>
{
    public required User User { get; set; }
}