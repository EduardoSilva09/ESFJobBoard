﻿// <auto-generated />
using System;
using ESFJobBoard.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ESFJobBoard.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(JobBoardDbContext))]
    [Migration("20240227002452_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ESFJobBoard.Core.Entities.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DatePosted")
                        .HasColumnType("datetime")
                        .HasColumnName("DatePosted");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<int>("EmployerId")
                        .HasColumnType("int")
                        .HasColumnName("EmployerId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Title");

                    b.HasKey("Id");

                    b.ToTable("Jobs", (string)null);
                });

            modelBuilder.Entity("ESFJobBoard.Core.Entities.JobApplication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ApplicationDate")
                        .HasColumnType("datetime")
                        .HasColumnName("ApplicationDate");

                    b.Property<int>("JobId")
                        .HasColumnType("int")
                        .HasColumnName("JobId");

                    b.Property<int>("JobSeekerId")
                        .HasColumnType("int")
                        .HasColumnName("JobSeekerId");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.HasIndex("JobSeekerId");

                    b.ToTable("Applications", (string)null);
                });

            modelBuilder.Entity("ESFJobBoard.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Password");

                    b.Property<int>("UserType")
                        .HasColumnType("int")
                        .HasColumnName("UserType");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Username");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("ESFJobBoard.Core.Entities.JobApplication", b =>
                {
                    b.HasOne("ESFJobBoard.Core.Entities.Job", "Job")
                        .WithMany("Applications")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ESFJobBoard.Core.Entities.User", "JobSeeker")
                        .WithMany("Applications")
                        .HasForeignKey("JobSeekerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");

                    b.Navigation("JobSeeker");
                });

            modelBuilder.Entity("ESFJobBoard.Core.Entities.Job", b =>
                {
                    b.Navigation("Applications");
                });

            modelBuilder.Entity("ESFJobBoard.Core.Entities.User", b =>
                {
                    b.Navigation("Applications");
                });
#pragma warning restore 612, 618
        }
    }
}
