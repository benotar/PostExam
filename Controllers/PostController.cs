using Exam.Entities;
using Exam.Entities.DTOs;
using Exam.SQRS.Commands;
using Exam.SQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class PostController : Controller
{
    private readonly ISender _sender;

    public PostController(ISender sender) => _sender = sender;

    [HttpGet]
    public async Task<ActionResult<List<PostDto>>> GetAllPosts()
    {
        var posts = await _sender.Send(new GetAllPostsQuery());

        if (posts is null)
        {
            return NotFound("Posts not found in database!");
        }

        return Ok(posts);
    }
    
    [HttpPost]
    public async Task<ActionResult<Post>> CreatePost(CreatePostCommand command)
    {
        var post = await _sender.Send(command);

        return Ok(post);
    }
}