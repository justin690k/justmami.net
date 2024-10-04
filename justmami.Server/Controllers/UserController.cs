using justmami.Application.Users.Commands.AddUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Silk.DDD.Results;

namespace justmami.Server.Controllers;
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IMediator _mediator;

    public UserController(ILogger<UserController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPut(Name = "AddUser")]
    public async Task<IActionResult> Add([FromBody] AddUserCommand command)
    {
        Result<bool> result = await _mediator.Send(command);
        return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
    }
}
