namespace justmami.Application.Commands.DeleteUser;
public class DeleteUserCommand : ICommand<Result<bool>>
{
    public required int Id { get; set; }
}
