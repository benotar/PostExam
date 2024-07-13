using Exam.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam.EntityTypeConfigurations;

public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
{
    public void Configure(EntityTypeBuilder<Feedback> builder)
    {
        builder.HasKey(feedback => feedback.Id);

        builder.HasIndex(feedback => feedback.Id);

        builder.Property(feedback => feedback.Title)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(feedback => feedback.Text)
            .IsRequired()
            .HasMaxLength(512);

        builder.Property(feedback => feedback.Rating)
            .IsRequired()
            .HasDefaultValue(0);

        builder.Property(feedback => feedback.UserId).IsRequired();

        builder.Property(feedback => feedback.PostId).IsRequired();
        
        builder.HasOne(feedback => feedback.User)
            .WithMany(user => user.Feedbacks)
            .HasForeignKey(user => user.UserId);

        builder.HasOne(feedback => feedback.Post)
            .WithMany(post => post.Feedbacks)
            .HasForeignKey(post => post.PostId);



        builder.Property(feedback => feedback.Id).HasColumnName("id");
        builder.Property(feedback => feedback.Title).HasColumnName("title");
        builder.Property(feedback => feedback.Text).HasColumnName("text");
        builder.Property(feedback => feedback.Rating).HasColumnName("rating");
        builder.Property(feedback => feedback.UserId).HasColumnName("user_id");
        builder.Property(feedback => feedback.PostId).HasColumnName("post_id");
        builder.Property(feedback => feedback.CreatedAt).HasColumnName("created_at");
        builder.Property(feedback => feedback.UpdatedAt).HasColumnName("updated_at");
    }
}