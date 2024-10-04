namespace justmami.Application.Users.Commands.DeleteUser;
public class DeleteUserCommand : ICommand<Result<bool>>
{
    public required int Id { get; set; }
}
