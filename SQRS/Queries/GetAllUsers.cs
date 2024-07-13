using Exam.Data;
using Exam.Entities;
using Exam.Entities.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Exam.SQRS.Queries;

public record GetAllUsersQuery : IRequest<IEnumerable<UserDto>>;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDto>>
{
    private readonly IPostsDbContext _db;

    public GetAllUsersQueryHandler(IPostsDbContext db) => _db = db;

    public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _db.Users
            .Select(user => new UserDto
            {
                Id = user.Id,
                LastName = user.LastName,
                FirstName = user.FirstName,
            }).ToListAsync(cancellationToken);

        return users;
    }
}