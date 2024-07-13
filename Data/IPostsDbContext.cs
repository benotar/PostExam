using Exam.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exam.Data;

public interface IPostsDbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }
    public DbSet<Post> Posts { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}