using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<ScheduledTask> ScheduledTasks { get; set; } = null!;
        public DbSet<RepeatScheduledTask> RepeatScheduledTasks { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
