using Exam.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam.EntityTypeConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(user => user.Id);
        
        builder.HasIndex(user => user.Id);

        builder.Property(user => user.FirstName)
            .IsRequired()
            .HasMaxLength(64);
        
        builder.HasMany(user => user.Feedbacks)
            .WithOne(feedback => feedback.User)
            .HasForeignKey(feedback => feedback.UserId);
        
        builder.Property(user => user.Id).HasColumnName("id");
        builder.Property(user => user.LastName).HasColumnName("last_name");
        builder.Property(user => user.LastName).HasColumnName("first_name");
        builder.Property(user => user.CreatedAt).HasColumnName("created_at");
        builder.Property(user => user.UpdatedAt).HasColumnName("updated_at");
    }
}