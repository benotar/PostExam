using Exam.Data;
using Exam.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Exam.SQRS.Commands;

public record CreateUserCommand(string LastName, string FirstName) : IRequest<User>;

public class CreateUserCommandHanlder : IRequestHandler<CreateUserCommand, User>
{
    private readonly IPostsDbContext _db;

    public CreateUserCommandHanlder(IPostsDbContext db) => _db = db; 
    
    public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.FirstName))
        {
            throw new ArgumentException("FirstName must be not empty!");
        }

        var existingUser = await _db.Users.Where(u => u.FirstName == request.FirstName).FirstOrDefaultAsync(cancellationToken);
        
        if(existingUser is not null)
        {
            throw new ArgumentException($"User \'{existingUser.FirstName}\' already exists in database!");
        }

        var user = new User
        {
            LastName = request.LastName,
            FirstName = request.FirstName
        };

        await _db.Users.AddAsync(user, cancellationToken);

        await _db.SaveChangesAsync(cancellationToken);

        return user;
    }
}