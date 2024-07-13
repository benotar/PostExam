using Exam.Data;
using Exam.Entities.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Exam.SQRS.Queries;

public record GetAllFeedbacksQuery : IRequest<IEnumerable<FeedbackDto>>;

public class GetAllFeedbacksQueryHandler : IRequestHandler<GetAllFeedbacksQuery, IEnumerable<FeedbackDto>>
{
    private readonly IPostsDbContext _db;

    public GetAllFeedbacksQueryHandler(IPostsDbContext db) => _db = db;

    public async Task<IEnumerable<FeedbackDto>> Handle(GetAllFeedbacksQuery request, CancellationToken cancellationToken)
    {
        var feedbacks = await _db.Feedbacks
            .Select(feedback => new FeedbackDto
            {
                Id = feedback.Id,
                Title = feedback.Title,
                Text = feedback.Text,
                Rating = feedback.Rating,
                UserId = feedback.UserId,
                PostId = feedback.PostId
            }).ToListAsync(cancellationToken);

        return feedbacks;
    }
}
