using Microsoft.EntityFrameworkCore;
using Project.Domain.Aggregates;

namespace Project.Infrastructure.Persistence;
public class ProjectDbContext:DbContext
{
    public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options) { }

    public DbSet<ProjectAggregate> Projects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProjectDbContext).Assembly);
    }
}
