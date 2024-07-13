using Exam.Entities;
using Exam.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Exam.Data;

public class PostsDbContext : DbContext, IPostsDbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }
    public DbSet<Post> Posts { get; set; }

    public PostsDbContext(DbContextOptions<PostsDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new FeedbackConfiguration());
        modelBuilder.ApplyConfiguration(new PostConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}