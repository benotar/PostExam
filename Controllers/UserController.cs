using Exam.Entities;
using Exam.Entities.DTOs;
using Exam.SQRS.Commands;
using Exam.SQRS.Queries;
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

    [HttpGet]
    public async Task<ActionResult<List<UserDto>>> GetUsers()
    {
        var users = await _sender.Send(new GetAllUsersQuery());

        if (users is null)
        {
            return NotFound("Users not found in database!");
        }
        
        return Ok(users);
    }
    
    [HttpPost]
    public async Task<ActionResult<User>> Create(CreateUserCommand command)
    {
        var user = await _sender.Send(command);

        return Ok(user);
    }
}