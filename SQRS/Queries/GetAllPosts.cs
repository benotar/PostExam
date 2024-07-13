using Exam.Data;
using Exam.Entities.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Exam.SQRS.Queries;

public record GetAllPostsQuery : IRequest<IEnumerable<PostDto>>;

public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, IEnumerable<PostDto>>
{ 
    private readonly IPostsDbContext _db;

    public GetAllPostsQueryHandler(IPostsDbContext db) => _db = db;


    public async Task<IEnumerable<PostDto>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
    {
        var posts = await _db.Posts
            .Select(post => new PostDto
            {
                Id = post.Id,
                Title = post.Title
            }).ToListAsync(cancellationToken);

        return posts;
    }
}