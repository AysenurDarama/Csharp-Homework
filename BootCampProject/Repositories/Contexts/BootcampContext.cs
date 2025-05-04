using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Configurations;

namespace Repositories.Contexts;

public class BootcampContext : DbContext
{
    public BootcampContext(DbContextOptions<BootcampContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Applicant> Applicants { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Instructor> Instructors { get; set; }

    public DbSet<Application> Applications { get; set; }
    public DbSet<Bootcamp> Bootcamps { get; set; }
    public DbSet<Blacklist> Blacklists { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ApplicationConfiguration());
        modelBuilder.ApplyConfiguration(new BootcampConfiguration());
        modelBuilder.ApplyConfiguration(new BlacklistConfiguration());
    }
}
