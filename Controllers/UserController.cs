using Exam.Entities;
using Exam.SQRS.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Controllers;


[ApiController]
[Route("api/[controller]/[action]")]
public class UserController : Controller
{
    private readonly ISender _sender;

    public UserController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<ActionResult<User>> Create(CreateUserCommand command)
    {
        var user = await _sender.Send(command);

        return Ok(user);
    }
}