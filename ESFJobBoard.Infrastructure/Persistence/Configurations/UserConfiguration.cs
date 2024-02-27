using ESFJobBoard.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESFJobBoard.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Configure the User entity
            builder.ToTable("Users"); // Set the table name

            // Primary key
            builder.HasKey(u => u.Id);

            // Properties
            builder.Property(u => u.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(u => u.Username)
                .HasColumnName("Username")
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder.Property(u => u.Password)
                .HasColumnName("Password")
                .HasColumnType("nvarchar(255)")
                .IsRequired();

            builder.Property(u => u.UserType)
                .HasColumnName("UserType")
                .HasColumnType("int")
                .IsRequired();

            // Navigation properties
            builder.HasMany(u => u.Applications)
                .WithOne(ja => ja.JobSeeker)
                .HasForeignKey(ja => ja.JobSeekerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(u => u.Applications)
                .UsePropertyAccessMode(PropertyAccessMode.Property);
        }
    }
}