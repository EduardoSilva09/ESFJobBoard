using ESFJobBoard.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESFJobBoard.Infrastructure.Persistence.Configurations
{
    public class JobApplicationConfiguration : IEntityTypeConfiguration<JobApplication>
    {
        public void Configure(EntityTypeBuilder<JobApplication> builder)
        {
            // Configure the JobApplication entity
            builder.ToTable("Applications"); // Set the table name

            // Primary key
            builder.HasKey(ja => ja.Id);

            // Foreign keys
            builder.HasOne(ja => ja.Job)
                .WithMany(j => j.Applications)
                .HasForeignKey(ja => ja.JobId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete if a job is deleted

            builder.HasOne(ja => ja.JobSeeker)
                .WithMany(u => u.Applications)
                .HasForeignKey(ja => ja.JobSeekerId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete if a job seeker is deleted

            // Properties
            builder.Property(ja => ja.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(ja => ja.JobId)
                .HasColumnName("JobId")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(ja => ja.JobSeekerId)
                .HasColumnName("JobSeekerId")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(ja => ja.ApplicationDate)
                .HasColumnName("ApplicationDate")
                .HasColumnType("datetime")
                .IsRequired();
        }
    }
}