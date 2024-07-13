using Exam.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam.EntityTypeConfigurations;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(post => post.Id);

        builder.HasIndex(p => p.Id);

        builder.Property(post => post.Title)
            .IsRequired()
            .HasMaxLength(255);
        
        builder.HasMany(post => post.Feedbacks)
            .WithOne(feedback => feedback.Post)
            .HasForeignKey(feedback => feedback.PostId);

        builder.Property(post => post.Id).HasColumnName("id");
        builder.Property(post => post.Title).HasColumnName("title");
        builder.Property(post => post.CreatedAt).HasColumnName("created_at");
        builder.Property(post => post.UpdatedAt).HasColumnName("updated_at");
    }
}