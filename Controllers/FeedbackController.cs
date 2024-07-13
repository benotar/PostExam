using Exam.Entities;
using Exam.Entities.DTOs;
using Exam.SQRS.Commands;
using Exam.SQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class FeedbackController : Controller
{
    private readonly ISender _sender;

    public FeedbackController(ISender sender) => _sender = sender;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FeedbackDto>>> GetAllFeedback()
    {
        var feedbacks = await _sender.Send(new GetAllFeedbacksQuery());

        if (feedbacks is null)
        {
            return NotFound("Feedbacks not found in database!");
        }

        return Ok(feedbacks);
    }

    [HttpPost]
    public async Task<ActionResult<Feedback>> CreateFeedback(CreateFeedbackCommand command)
    {
        var feedback = await _sender.Send(command);

        return Ok(feedback);
    }
}