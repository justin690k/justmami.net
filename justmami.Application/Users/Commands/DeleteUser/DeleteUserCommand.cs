using justmami.Application.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace justmami.Application.Users.Commands.DeleteUser;
public class DeleteUserCommand : ICommand<Result<bool>>
{
    public required int Id { get; set; }
}
