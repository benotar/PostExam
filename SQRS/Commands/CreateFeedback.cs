using Exam.Data;
using Exam.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using str = string;

namespace Exam.SQRS.Commands;

public record CreateFeedbackCommand(str Title, str Text, int Rating, int UserId, int PostId)
    : IRequest<Feedback>;

public class CreateFeedbackCommandHandler : IRequestHandler<CreateFeedbackCommand, Feedback>
{
    private readonly IPostsDbContext _db;

    public CreateFeedbackCommandHandler(IPostsDbContext db) => _db = db;

    public async Task<Feedback> Handle(CreateFeedbackCommand request, CancellationToken cancellationToken)
    {
        if (str.IsNullOrEmpty(request.Title))
        {
            throw new ArgumentException("Title must be not empty!");
        }
        
        if (str.IsNullOrEmpty(request.Text))
        {
            throw new ArgumentException("Text must be not empty!");
        }
        
        if (request.Rating < 0)
        {
            throw new ArgumentException("Incorrect rating!");
        }

        var existingUser = await _db.Users.Where(u => u.Id == request.UserId).FirstOrDefaultAsync(cancellationToken);

        if (existingUser is null)
        {
            throw new KeyNotFoundException("User not found in database!");
        }

        var existingPost = await _db.Posts.Where(p => p.Id == request.PostId).FirstOrDefaultAsync(cancellationToken);
        
        if (existingPost is null)
        {
            throw new KeyNotFoundException("Post not found in database!");
        }

        var feedback = new Feedback
        {
            Title = request.Title,
            Text = request.Text,
            Rating = request.Rating,
            //User = existingUser,
            UserId = existingUser.Id,
            //Post = existingPost,
            PostId = existingPost.Id,
        };

        await _db.Feedbacks.AddAsync(feedback, cancellationToken);

        //existingUser.Feedbacks.Add(feedback);
        //existingPost.Feedbacks.Add(feedback);
        
        await _db.SaveChangesAsync(cancellationToken);

        return feedback;
    }
}