using Microsoft.EntityFrameworkCore;
using MVC_Lab.Models;

namespace MVC_Lab.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {    
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EmployeeProject>().HasKey(e => new { e.EmployeeId, e.ProjectId });
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Employee> employees  { get; set; }
        public DbSet<EmployeeProject> employeesProjects { get; set; }

    }
}
