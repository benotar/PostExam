using Exam.Data;
using Exam.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Exam.SQRS.Commands;

public record CreatePostCommand(string title) : IRequest<Post>;

public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Post>
{
    private readonly IPostsDbContext _db;

    public CreatePostCommandHandler(IPostsDbContext db) => _db = db;

    public async Task<Post> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.title))
        {
            throw new ArgumentException("Title must be not empty!");
        }
        
        var post = new Post()
        {
            Title = request.title
        };

        await _db.Posts.AddAsync(post, cancellationToken);

        await _db.SaveChangesAsync(cancellationToken);

        return post;
    }
}