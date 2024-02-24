using System.Reflection;
using ESFJobBoard.API.Model;
using Microsoft.EntityFrameworkCore;

namespace ESFJobBoard.API.DAO
{
    public class JobBoardDbContext : DbContext
    {
        public JobBoardDbContext(DbContextOptions<JobBoardDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobApplication> Applications { get; set; }

    }
}