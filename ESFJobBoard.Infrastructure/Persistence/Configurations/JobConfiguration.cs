using ESFJobBoard.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESFJobBoard.Infrastructure.Persistence.Configurations
{
    public class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            // Configure the Job entity
            builder.ToTable("Jobs"); // Set the table name

            // Primary key
            builder.HasKey(j => j.Id);

            // Properties
            builder.Property(j => j.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(j => j.EmployerId)
                .HasColumnName("EmployerId")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(j => j.Title)
                .HasColumnName("Title")
                .HasColumnType("nvarchar(255)")
                .IsRequired();

            builder.Property(j => j.Description)
                .HasColumnName("Description")
                .HasColumnType("nvarchar(max)")
                .IsRequired();

            builder.Property(j => j.DatePosted)
                .HasColumnName("DatePosted")
                .HasColumnType("datetime")
                .IsRequired();

            // Navigation properties
            builder.HasMany(j => j.Applications)
                .WithOne(ja => ja.Job)
                .HasForeignKey(ja => ja.JobId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(j => j.Applications)
                .UsePropertyAccessMode(PropertyAccessMode.Property);
        }
    }
}