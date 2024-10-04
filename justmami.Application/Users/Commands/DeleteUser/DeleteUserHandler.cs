namespace justmami.Application.Users.Commands.DeleteUser;
public class DeleteUserHandler : CommandHandler<DeleteUserCommand, Result<bool>>
{
    public override async Task<Result<bool>> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
    {
        //Access Repository
        await Task.Delay(100);

        return Result<bool>.Success(true);
    }
}
